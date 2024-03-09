using System.Net;
using System.Runtime.Serialization;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Serilog;
using TransportNetwork;

namespace DataFetcher;

public class TflModelWrapper : INetworkDataSource
{
    private StopPointApi _stationFetcher;
    private LineApi _lineApi;
    private ILogger _logger;
    private string _cachePath;
    private const int MaxCacheAge = 30; // days

    private const int PercentOfTotal = 90;
    private const double InitialPercent = 3.0;
    private Action<double> _progressCallback = (double _) => { };
    public TflModelWrapper(ILogger logger, string cachePath = "")
    {
        this._logger = logger;
        var apiconfig = new Configuration
        {
            BasePath = "https://api.tfl.gov.uk"
        };
        _lineApi = new LineApi(apiconfig);
        _stationFetcher = new StopPointApi(apiconfig);

        this._cachePath = cachePath;
        
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

        throw new InvalidBranchIdException("Sequence did not contain a segment with given ID!");
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
                string currentId = segment.StopPoint[i].Id;
                network.AddStationId(currentId, segment.StopPoint[i].Name);
                    
                // link the previous station (if it exists) to the current station, in an ordered way
                if (i > 0)
                {
                    string prevId = segment.StopPoint[i - 1].Id;
                    network.LinkStationsPartial(prevId, currentId, direction, currentLine);
                }
            }
        }
    }

    public void PopulateNetworkStructure(ref Network network)
    {
        _logger.Information("Populating network from cache at {A}...", _cachePath);
        _progressCallback(0.0);
        // use caches if possible
        if (File.Exists($"{_cachePath}lastUpdated.txt"))
        {
            // check if the cache is older than 24 hours
            DateTime lastUpdated = File.GetLastWriteTime($"{_cachePath}lastUpdated.txt");
            if (lastUpdated < DateTime.Now.AddDays(-MaxCacheAge))
            {
                _logger.Information($"Cache is older than {MaxCacheAge} days, updating...");
                UpdateStructureCache();
            }
        }
        else
        {
            _logger.Information("No cache found at {A}, updating...", _cachePath);
            UpdateStructureCache();
        }

        try
        {
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (System.IO.FileNotFoundException)
        {
            _logger.Warning("Cache file missing!, Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (System.Runtime.Serialization.SerializationException)
        {
            _logger.Warning("Cache file corrupt! Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        
        PopulateNetworkTimesTimingsLib(ref network);
        _progressCallback(100.0);
    }

    public void SetProgressCallback(Action<double> callback)
    {
        _progressCallback = callback;
    }

    private void PopulateNetworkStructureFromCache(ref Network network)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        DataContractSerializer lineSerializer =
            new DataContractSerializer(typeof(List<TflApiPresentationEntitiesLine>));
        List<TflApiPresentationEntitiesLine> rawLines;
        using (FileStream fs = new FileStream($"{_cachePath}lines.xml", FileMode.Open))
        {
            rawLines = (List<TflApiPresentationEntitiesLine>) lineSerializer.ReadObject(fs);
        }
        _logger.Debug("Got {A} lines from cached file", rawLines.Count);
        
        List<Line> lines = new List<Line>();
        foreach (var l in rawLines)
        {
            lines.Add(new Line(l.Id, l.Name));
        }
        
        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesRouteSequence));
        foreach (Line line in lines)
        {
            _logger.Debug("Processing segments for line {A}", line.Name);
            
            TflApiPresentationEntitiesRouteSequence inboundResult;
            using (FileStream fs = new FileStream($"{_cachePath}{line.Id}_inbound.xml", FileMode.Open))
            {
                inboundResult = (TflApiPresentationEntitiesRouteSequence) serializer.ReadObject(fs);
            }
            
            AddLinksForLineSequence(inboundResult.StopPointSequences, ref network, line, Dir.Inbound);
            
            // process outbound separately as our graph is directed
            TflApiPresentationEntitiesRouteSequence outboundResult;
            using (FileStream fs = new FileStream($"{_cachePath}{line.Id}_outbound.xml", FileMode.Open))
            {
                outboundResult = (TflApiPresentationEntitiesRouteSequence) serializer.ReadObject(fs);
            }
            
            AddLinksForLineSequence(outboundResult.StopPointSequences, ref network, line, Dir.Outbound);
        }
        _logger.Debug("Done in {A}ms", watch.ElapsedMilliseconds);
    } 

    private void UpdateStructureCache()
    {
        _progressCallback(InitialPercent);
        var watch = System.Diagnostics.Stopwatch.StartNew(); // timer to report performance in logs

        _logger.Information("Populating local cache from API...");
        var rawLines = _lineApi.LineGetByMode(new List<string> { "tube" });
        _logger.Debug("Got {A} lines from API", rawLines.Count);
        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesRouteSequence));
        
        // create cache directory if it doesn't exist
        if (!string.IsNullOrWhiteSpace(_cachePath))
        {
            Directory.CreateDirectory(_cachePath);
        }

        // cache which lines there are too to be completely independent of the API in case of no network connection
        DataContractSerializer lineSerializer =
            new DataContractSerializer(typeof(List<TflApiPresentationEntitiesLine>));
        using (FileStream fs = new FileStream($"{_cachePath}lines.xml", FileMode.Create))
        {
            lineSerializer.WriteObject(fs, rawLines);
        }
        
        for (int idx = 0; idx < rawLines.Count; idx++)
        {
            _logger.Debug("Processing inbound segments for line {A}", rawLines[idx].Id);
            
            watch.Restart();
            
            _progressCallback(InitialPercent + PercentOfTotal * idx / (double)rawLines.Count);

            TflApiPresentationEntitiesRouteSequence inboundResult = _lineApi.LineRouteSequence(rawLines[idx].Id, "inbound");
            _logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            using (FileStream fs = new FileStream($"{_cachePath}{rawLines[idx].Id}_inbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, inboundResult);
            }
            
            _progressCallback(InitialPercent + PercentOfTotal * (idx+0.5) / (double)rawLines.Count);
            
            // process outbound separately as our graph is directed
            _logger.Debug("Processing outbound segments for line {A}", rawLines[idx].Id);
            
            watch.Restart();
            TflApiPresentationEntitiesRouteSequence outboundResult = _lineApi.LineRouteSequence(rawLines[idx].Id, "outbound");
            _logger.Debug("Got {A} segments in {B}ms", inboundResult.StopPointSequences.Count, watch.ElapsedMilliseconds);
            
            using (FileStream fs = new FileStream($"{_cachePath}{rawLines[idx].Id}_outbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, outboundResult);
            }
            _logger.Information("Processing line {A}...", rawLines[idx].Name);
        }
        
        // write a metadata file so we know when the cache was updated
        using (FileStream fs = new FileStream($"{_cachePath}lastUpdated.txt", FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now.ToString());
            }
        }

        _progressCallback(InitialPercent + PercentOfTotal);
    }

    private void UpdateTimingsLib()
    {
        const string address = "https://raw.githubusercontent.com/Liftyee/tube-timings/main/data.txt";
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(address, $"{_cachePath}timingsData.txt");
        }
    }

    private void PopulateNetworkTimesTimingsLib(ref Network network)
    {
        _logger.Debug("Populating network times from timings file...");
        UpdateTimingsLib();
        using (StreamReader dataFile = File.OpenText($"{_cachePath}timingsData.txt"))
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
                    _logger.Debug("Tried to update a link that doesn't exist! {A} -> {B}", edgeDetails[0], edgeDetails[1]);
                    network.LinkStationsPartial(edgeDetails[0], edgeDetails[1], Dir.Bidirectional, new Line("Unknown", "Unknown"));
                    network.UpdateLink(edgeDetails[0], edgeDetails[1], new TimeSpan(0, minutes, seconds));
                }
            }
        }
    }

    private void PopulateNetworkTimes(ref Network network)
    {
        var rawLines = _lineApi.LineGetByMode(new List<string> { "tube" });
        _logger.Debug("Got {A} lines from API", rawLines.Count);

        foreach (var line in rawLines)
        {
            
        }
    }

    private void UpdateTimetableCache()
    {
        throw new NotImplementedException();
        var watch = System.Diagnostics.Stopwatch.StartNew(); // timer to report performance in logs
        
        var rawLines = _lineApi.LineGetByMode(new List<string> { "tube" });

        DataContractSerializer serializer = new DataContractSerializer(typeof(TflApiPresentationEntitiesTimetableResponse));
        foreach (var line in rawLines)
        {
            var stations = _lineApi.LineStopPoints(line.Id);
            _logger.Debug("Got {A} stations from API for line {B}", stations.Count, line.Name);
            foreach (var station in stations)
            {
                var result = _lineApi.LineTimetable(station.NaptanId, line.Id);
                
                using (FileStream fs = new FileStream($"{_cachePath}z{station.NaptanId}.xml", FileMode.Create))
                {
                    serializer.WriteObject(fs, result);
                }
            }
        }
    }
}
