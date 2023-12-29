using System.Diagnostics;
using System.Diagnostics.Metrics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Serilog;
using Serilog.Core;
using System.Diagnostics;
using Serilog.Debugging;
using TransportNetwork;

    
namespace DataFetcher;

public class LinearNetwork : INetworkDataFetcher
{
    private int numNodes;
    public LinearNetwork(int nNodes)
    {
        numNodes = nNodes;
    }
    public void PopulateNetworkStructure(ref Network network)
    {
        for (int i = 0; i < numNodes; i++)
        {
            network.AddStationByIdIfNotPresent(i.ToString());
        }

        for (int i = 0; i < numNodes - 1; i++)
        {
            network.LinkStationsPartial(i.ToString(), (i + 1).ToString(), Dir.Inbound);
            network.LinkStationsPartial((i+1).ToString(), i.ToString(), Dir.Outbound);
        }
    }
}

public class InvalidBranchIDException : Exception
{
    public InvalidBranchIDException(string message) : base(message)
    {
    }
}

public class TfLModelWrapper : INetworkDataFetcher
{
    private StopPointApi stationFetcher;
    private LineApi lineApi;
    private Dictionary<string, TflApiPresentationEntitiesStopPoint> stationCache;
    private List<TflApiPresentationEntitiesLine> lineCache;
    private ILogger logger;
    public TfLModelWrapper(ILogger logger)
    {
        this.logger = logger;
        var apiconfig = new Configuration
        {
            BasePath = "https://api.tfl.gov.uk"
        };
        lineApi = new LineApi(apiconfig);
        stationFetcher = new StopPointApi(apiconfig);
        stationCache = new Dictionary<string, TflApiPresentationEntitiesStopPoint>();
        lineCache = new List<TflApiPresentationEntitiesLine>();
        logger.Debug("TfL API data fetcher initialised at {A}", apiconfig.BasePath);
    }

    public List<Station> GetStations()
    {
        throw new NotImplementedException();
    }

    public List<Line> GetLinks()
    {
        throw new NotImplementedException();
    }

    public void UpdateStationData(ref Station station)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCaches(List<string> lineNames)
    {
        lineCache = lineApi.LineGet(lineNames);
        foreach (TflApiPresentationEntitiesLine line in lineCache)
        {
            List<TflApiPresentationEntitiesStopPoint> linestations = lineApi.LineStopPoints(line.Id);
            foreach (TflApiPresentationEntitiesStopPoint station in linestations)
            {
                stationCache[station.NaptanId] = station;
            }
        }
        return true;
    }

    public void UpdateLineData(ref Line line)
    {
        throw new NotImplementedException();
    }

    internal TflApiPresentationEntitiesStopPointSequence GetSequenceById(List<TflApiPresentationEntitiesStopPointSequence> segments,
        int id)
    {
        foreach (TflApiPresentationEntitiesStopPointSequence seq in segments)
        {
            if (seq.BranchId == id)
            {
                return seq;
            }
        }

        throw new InvalidBranchIDException("Sequence did not contain a segment with given ID!");
    }

    internal TflApiPresentationEntitiesMatchedStop GetFirstStop(TflApiPresentationEntitiesStopPointSequence segment)
    {
        return segment.StopPoint[0];
    }

    internal TflApiPresentationEntitiesMatchedStop GetLastStop(TflApiPresentationEntitiesStopPointSequence segment)
    {
        return segment.StopPoint.Last();
    }

    public void AddLinksForLineSequence(List<TflApiPresentationEntitiesStopPointSequence> segments, ref Network network, Line currentLine, Dir direction)
    {
        for (int j = 0; j < segments.Count; j++)
        {
            var segment = segments[j];
                
            // link the stations together
            for (int i = 0; i < segment.StopPoint.Count; i++)
            {
                string currentID = segment.StopPoint[i].Id;
                network.AddStationByIdIfNotPresent(currentID);
                    
                // link the previous station (if it exists) to the current station, in an ordered way
                if (i > 0)
                {
                    string prevID = segment.StopPoint[i - 1].Id;
                    network.LinkStationsPartial(prevID, currentID, direction, currentLine);
                }
            }
                
            // we need to link this route segment to its next ones if present
            foreach (int id in segment.NextBranchIds)
            {
                var lastStationOfCurrentSegment = GetLastStop(segment);

                try
                {
                    var firstStationOfNextSegment = GetFirstStop(GetSequenceById(segments, id));
                    // link the last station of our segment to the first station of the new chain
                    network.AddStationByIdIfNotPresent(lastStationOfCurrentSegment.Id, lastStationOfCurrentSegment.Name);
                    network.AddStationByIdIfNotPresent(firstStationOfNextSegment.Id, firstStationOfNextSegment.Name);
                    network.LinkStationsPartial(lastStationOfCurrentSegment.Id, firstStationOfNextSegment.Id, direction, currentLine);
                } catch (InvalidBranchIDException ex)
                {
                    logger.Warning("Segment list (on line {A}) did not contain a segment with given ID {B}! Search started by segment id {C}",
                        currentLine.Id,
                        id,
                        segment.BranchId);
                }
            }
            #warning "Need to add line information to the links!"
        }
    }
    
    public void PopulateNetworkStructure(ref Network network)
    {
        logger.Information("Populating network from API data...");
        var watch = System.Diagnostics.Stopwatch.StartNew(); // performance timing stopwatch
        
        var rawLines = lineApi.LineGetByMode(new List<string> { "tube" });
        logger.Debug("Got {A} lines from API", rawLines.Count);
        
        List<Line> lines = new List<Line>();
        foreach (var l in rawLines)
        {
            lines.Add(new Line(l.Id, l.Name));
        }
        
        foreach (Line line in lines)
        {
            logger.Debug("Processing inbound segments for line {A}", line.Name);
            
            watch.Restart();
            TflApiPresentationEntitiesRouteSequence inboundResult = lineApi.LineRouteSequence(line.Id, "inbound");
            logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            AddLinksForLineSequence(inboundResult.StopPointSequences, ref network, line, Dir.Inbound);
            
            // process outbound separately as our graph is directed
            logger.Debug("Processing outbound segments for line {A}", line.Name);
            
            watch.Restart();
            TflApiPresentationEntitiesRouteSequence outboundResult = lineApi.LineRouteSequence(line.Id, "outbound");
            logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            AddLinksForLineSequence(outboundResult.StopPointSequences, ref network, line, Dir.Outbound);
        }
    }
}