using System.Net;
using System.Runtime.Serialization;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Serilog;
using TransportNetwork;

namespace DataFetcher;

public class TflModelWrapper : INetworkDataFetcher
{
    private StopPointApi stationFetcher;
    private LineApi lineApi;
    private ILogger logger;
    private string cachePath;
    private const int maxCacheAge = 30; // days
    public TflModelWrapper(ILogger logger, string cachePath)
    {
        this.logger = logger;
        var apiconfig = new Configuration
        {
            BasePath = "https://api.tfl.gov.uk"
        };
        lineApi = new LineApi(apiconfig);
        stationFetcher = new StopPointApi(apiconfig);

        this.cachePath = cachePath;
        
        logger.Debug("TfL API data fetcher initialised at {A}", apiconfig.BasePath);
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
                network.AddStationByIdIfNotPresent(currentID, segment.StopPoint[i].Name);
                    
                // link the previous station (if it exists) to the current station, in an ordered way
                if (i > 0)
                {
                    string prevID = segment.StopPoint[i - 1].Id;
                    network.LinkStationsPartial(prevID, currentID, direction, currentLine);
                }
            }
                
            // we need to link this route segment to its next ones if present
            // TODO: actually not needed since the ends of route segments overlap
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
        logger.Information("Populating network from cache at {A}...", cachePath);
        // use caches if possible
        if (File.Exists($"{cachePath}lastUpdated.txt"))
        {
            // check if the cache is older than 24 hours
            DateTime lastUpdated = File.GetLastWriteTime($"{cachePath}lastUpdated.txt");
            if (lastUpdated < DateTime.Now.AddDays(-maxCacheAge))
            {
                logger.Information($"Cache is older than {maxCacheAge} days, updating...");
                UpdateStructureCache();
            }
        }
        else
        {
            logger.Information("No cache found at {A}, updating...", cachePath);
            UpdateStructureCache();
        }

        try
        {
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (System.IO.FileNotFoundException)
        {
            logger.Warning("Cache file missing!, Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (System.Runtime.Serialization.SerializationException)
        {
            logger.Warning("Cache file corrupt! Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        
        PopulateNetworkTimesEliyahuLib(ref network);
    }

    private void PopulateNetworkStructureFromCache(ref Network network)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        DataContractSerializer lineSerializer =
            new DataContractSerializer(typeof(List<TflApiPresentationEntitiesLine>));
        List<TflApiPresentationEntitiesLine> rawLines;
        using (FileStream fs = new FileStream($"{cachePath}lines.xml", FileMode.Open))
        {
            rawLines = (List<TflApiPresentationEntitiesLine>) lineSerializer.ReadObject(fs);
        }
        logger.Debug("Got {A} lines from cached file", rawLines.Count);
        
        List<Line> lines = new List<Line>();
        foreach (var l in rawLines)
        {
            lines.Add(new Line(l.Id, l.Name));
        }
        
        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesRouteSequence));
        foreach (Line line in lines)
        {
            logger.Debug("Processing segments for line {A}", line.Name);
            
            TflApiPresentationEntitiesRouteSequence inboundResult;
            using (FileStream fs = new FileStream($"{cachePath}{line.Id}_inbound.xml", FileMode.Open))
            {
                inboundResult = (TflApiPresentationEntitiesRouteSequence) serializer.ReadObject(fs);
            }
            
            AddLinksForLineSequence(inboundResult.StopPointSequences, ref network, line, Dir.Inbound);
            
            // process outbound separately as our graph is directed
            TflApiPresentationEntitiesRouteSequence outboundResult;
            using (FileStream fs = new FileStream($"{cachePath}{line.Id}_outbound.xml", FileMode.Open))
            {
                outboundResult = (TflApiPresentationEntitiesRouteSequence) serializer.ReadObject(fs);
            }
            
            AddLinksForLineSequence(outboundResult.StopPointSequences, ref network, line, Dir.Outbound);
        }
        logger.Information("Done in {A}ms", watch.ElapsedMilliseconds);
    } 

    private void UpdateStructureCache()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew(); // timer to report performance in logs

        logger.Information("Populating local cache from API...");
        var rawLines = lineApi.LineGetByMode(new List<string> { "tube" });
        logger.Debug("Got {A} lines from API", rawLines.Count);
        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesRouteSequence));
        
        // create cache directory if it doesn't exist
        Directory.CreateDirectory(cachePath);

        // cache which lines there are too to be completely independent of the API in case of no network connection
        DataContractSerializer lineSerializer =
            new DataContractSerializer(typeof(List<TflApiPresentationEntitiesLine>));
        using (FileStream fs = new FileStream($"{cachePath}lines.xml", FileMode.Create))
        {
            lineSerializer.WriteObject(fs, rawLines);
        }
        
        foreach (var line in rawLines)
        {
            logger.Debug("Processing inbound segments for line {A}", line.Id);
            
            watch.Restart();
            TflApiPresentationEntitiesRouteSequence inboundResult = lineApi.LineRouteSequence(line.Id, "inbound");
            logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            // TODO: path doesn't work on Windows
            using (FileStream fs = new FileStream($"{cachePath}{line.Id}_inbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, inboundResult);
            }
            
            // process outbound separately as our graph is directed
            logger.Debug("Processing outbound segments for line {A}", line.Name);
            
            watch.Restart();
            TflApiPresentationEntitiesRouteSequence outboundResult = lineApi.LineRouteSequence(line.Id, "outbound");
            logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            using (FileStream fs = new FileStream($"{cachePath}{line.Id}_outbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, outboundResult);
            }
        }
        
        // write a metadata file so we know when the cache was updated
        using (FileStream fs = new FileStream($"{cachePath}lastUpdated.txt", FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now.ToString());
            }
        }
    }

    private void UpdateEliyahuLib()
    {
        const string address = "https://raw.githubusercontent.com/egkoppel/tube-timings/main/data.txt";
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(address, $"{cachePath}timingsData.txt");
        }
    }

    private void PopulateNetworkTimesEliyahuLib(ref Network network)
    {
        logger.Information("Populating network times from Eliyahu's library...");
        UpdateEliyahuLib();
        using (StreamReader dataFile = File.OpenText($"{cachePath}timingsData.txt"))
        {
            while (!dataFile.EndOfStream)
            {
                // parse line by line
                string rawLine = dataFile.ReadLine();
                string[] edgeDetails = rawLine.Split(" ");
                double decimalMinutes = System.Convert.ToDouble(edgeDetails[2]);
                int minutes = (int)Math.Floor(decimalMinutes);
                int seconds = (int)Math.Floor((decimalMinutes % 1) * 60);
                try
                {
                    network.UpdateLink(edgeDetails[0], edgeDetails[1], new TimeSpan(0, minutes, seconds));
                }
                catch (ArgumentException)
                {
                    logger.Warning("Tried to update a link that doesn't exist! {A} -> {B}", edgeDetails[0], edgeDetails[1]);
                }
            }
        }
    }

    private void PopulateNetworkTimes(ref Network network)
    {
        var rawLines = lineApi.LineGetByMode(new List<string> { "tube" });
        logger.Debug("Got {A} lines from API", rawLines.Count);

        foreach (var line in rawLines)
        {
            
        }
    }

    private void UpdateTimetableCache()
    {
        throw new NotImplementedException();
        var watch = System.Diagnostics.Stopwatch.StartNew(); // timer to report performance in logs
        
        var rawLines = lineApi.LineGetByMode(new List<string> { "tube" });

        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesTimetableResponse));
        foreach (var line in rawLines)
        {
            var stations = lineApi.LineStopPoints(line.Id);
            logger.Debug("Got {A} stations from API for line {B}", stations.Count, line.Name);
            foreach (var station in stations)
            {
                var result = lineApi.LineTimetable(station.NaptanId, line.Id);
                
                using (FileStream fs = new FileStream($"{cachePath}z{station.NaptanId}.xml", FileMode.Create))
                {
                    serializer.WriteObject(fs, result);
                }
            }
        }
    }
}
