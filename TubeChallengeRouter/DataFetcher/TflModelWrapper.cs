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
    private readonly LineApi _lineApi;
    private readonly ILogger _logger;
    private readonly string _cachePath;

    private const int MaxCacheAge = 30; // Cache invalid after 30 days (~1 month)
    // These are arbitrary values to make the progress bar behave nicely
    private const int PercentOfTotal = 90; // Value to reach when we are done
    private const double InitialPercent = 3.0; // Value to set when we start
    
    // This callback will be set by the GUI, and we will call it to update the
    // progress bar, but the empty lambda lets us operate without it
    private Action<double> _progressCallback = (_) => { };
    public TflModelWrapper(ILogger logger, string cachePath = "")
    {
        // Initialise the objects we'll need (logger and API client)
        this._logger = logger;
        var apiconfig = new Configuration
        {
            BasePath = "https://api.tfl.gov.uk"
        };
        _lineApi = new LineApi(apiconfig);

        this._cachePath = cachePath;
        
        logger.Debug("TfL API data fetcher initialised at {A}",
            apiconfig.BasePath);
    }

    // For a list of route segments and a given network+line+direction,
    // add the stations and links needed to represent that route segment 
    // to the network
    private void AddLineSeqLinks(
        List<TflApiPresentationEntitiesStopPointSequence> segments, 
        ref Network network, 
        string currentLineId, 
        Dir direction)
    {
        foreach (var segment in segments)
        {
            /* Link the stations within the segment
               NOTE: The segments are inclusive of adjacent segments' end 
               stations, so we don't need to explicitly link the ends of
               segments together */
            for (int i = 0; i < segment.StopPoint.Count; i++)
            {
                string currentId = segment.StopPoint[i].Id;
                
                // NOTE: Duplicate stations cannot be added to the network,
                // the AddStationId function only adds if not already present
                // Remove "Underground Station" from the name, it's repetitive
                network.AddStationId(currentId, segment.StopPoint[i].Name.
                    Replace(" Underground Station", ""));
                
                if (i > 0)
                {
                    string prevId = segment.StopPoint[i - 1].Id;
                    network.LinkStationsPartial(prevId, 
                        currentId, direction, currentLineId);
                }
            }
        }
    }

    // Check if the cache is too old, and try and update it if so
    private void EnsureCacheUpdated()
    {
        if (File.Exists($"{_cachePath}lastUpdated.txt"))
        {
            DateTime lastUpdated = 
                File.GetLastWriteTime($"{_cachePath}lastUpdated.txt");
            if (lastUpdated < DateTime.Now.AddDays(-MaxCacheAge))
            {
                _logger.Information($"Cache is outdated, updating...");
                try
                {
                    UpdateStructureCache();
                }
                catch (ApiException)
                {
                    _logger.Warning("Update failed, using old cache from {A}", lastUpdated);
                }
            }
        }
        else
        {
            _logger.Information("No cache found at {A}, updating...", _cachePath);
            UpdateStructureCache();
        }
    }

    // Populate a given network with the structure of the London Tube,
    // using the local cache if possible
    public void PopulateNetworkStructure(ref Network network)
    {
        _logger.Information("Populating network from cache at {A}...", _cachePath);
        _progressCallback(0.0);
        
        EnsureCacheUpdated();

        try
        {
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (FileNotFoundException)
        {
            _logger.Warning("Cache file missing!, Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        catch (SerializationException)
        {
            _logger.Warning("Cache file corrupt! Regenerating from API...");
            UpdateStructureCache();
            PopulateNetworkStructureFromCache(ref network);
        }
        
        PopulateNetworkTimesTimingsLib(ref network);
        _progressCallback(100.0);
    }

    // This setter implements an interface procedure, so we don't have to make
    // _progressCallback public
    public void SetProgressCallback(Action<double> callback)
    {
        _progressCallback = callback;
    }

    // Populate the given network with the stations and line structure of the 
    // London Tube, which is stored in our cache (caller must handle 
    // exceptions caused by the cache being invalid or missing)
    private void PopulateNetworkStructureFromCache(ref Network network)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Deserialize the line IDs from the cache
        DataContractSerializer lineSerializer = 
            new DataContractSerializer(
                typeof(List<TflApiPresentationEntitiesLine>));
        List<TflApiPresentationEntitiesLine> rawLines;
        using (FileStream fs = new($"{_cachePath}lines.xml", FileMode.Open))
        {
            rawLines = (List<TflApiPresentationEntitiesLine>) 
                lineSerializer.ReadObject(fs)!;
        }
        _logger.Debug("Got {A} lines from cached file", rawLines.Count);
        
        // Convert the Swagger API line objects to my own Line objects, as
        // well as adding the corresponding lines to the network
        // The created Line objects are never passed into the Network,
        // but are used to keep track of the lines within this function
        List<Line> lines = new List<Line>();
        foreach (TflApiPresentationEntitiesLine l in rawLines)
        {
            network.AddLine(l.Id, l.Name);
            lines.Add(new Line(l.Id, l.Name));
        }
        
        // Process the route segments of each line by deserialising the 
        // XML files we have cached
        DataContractSerializer serializer = new DataContractSerializer(
            typeof(TflApiPresentationEntitiesRouteSequence));
        foreach (Line line in lines)
        {
            _logger.Debug("Processing segments for line {A}", line.Name);
            string lp = $"{_cachePath}{line.Id}"; // path for current line
            
            List<TflApiPresentationEntitiesStopPointSequence> inboundResult;
            using FileStream ifs = new($"{lp}_inbound.xml", FileMode.Open);
            inboundResult = ((TflApiPresentationEntitiesRouteSequence) 
                serializer.ReadObject(ifs)!).StopPointSequences;
            
            AddLineSeqLinks(inboundResult, ref network, line.Id, Dir.Inbound);
            
            // Process outbound links separately as our graph is directed
            List<TflApiPresentationEntitiesStopPointSequence> outboundResult;
            using FileStream ofs = new($"{lp}_outbound.xml", FileMode.Open);
            outboundResult = ((TflApiPresentationEntitiesRouteSequence) 
                serializer.ReadObject(ofs)!).StopPointSequences;
            
            AddLineSeqLinks(outboundResult, ref network, line.Id, Dir.Outbound);
        }
        _logger.Debug("Done in {A}ms", watch.ElapsedMilliseconds);
    } 
    
    // Update the local cache of the Tube network structure
    // with the latest data from the TfL API
    private void UpdateStructureCache()
    {
        _progressCallback(InitialPercent);
        
        // Timer to track and report performance in logs
        var watch = System.Diagnostics.Stopwatch.StartNew(); 
        long totalMs = 0;

        _logger.Information("Populating local cache from API...");
        var rawLines = _lineApi.LineGetByMode(new List<string> { "tube" });
        _logger.Debug("Got {A} lines from API", rawLines.Count);
        
        // Instantiate a serializer we will use to cache the data
        DataContractSerializer serializer = new DataContractSerializer(
                typeof(TflApiPresentationEntitiesRouteSequence));
        
        // Create cache directory if it doesn't exist
        if (!string.IsNullOrWhiteSpace(_cachePath))
        {
            Directory.CreateDirectory(_cachePath);
        }

        // Cache which lines there are to be completely independent of the
        // API if the network connection is unavailable
        DataContractSerializer lineSerializer = new DataContractSerializer(
                typeof(List<TflApiPresentationEntitiesLine>));
        using (FileStream fs = new($"{_cachePath}lines.xml", FileMode.Create))
        {
            lineSerializer.WriteObject(fs, rawLines);
        }
        
        // Fetch and cache the data for each line
        for (int idx = 0; idx < rawLines.Count; idx++)
        {
            string cid = rawLines[idx].Id; // current line ID
            _logger.Information("Processing line {A}...", rawLines[idx].Name);
            _logger.Debug("Processing inbound segments for line {A}", cid);
            
            // File path + name for the current line
            string lp = $"{_cachePath}{cid}"; 
            _progressCallback(InitialPercent + PercentOfTotal * idx / 
                (double)rawLines.Count);
            watch.Restart();
            
            // Make API call for inbound route segments
            var inboundResult = _lineApi.LineRouteSequence(cid, "inbound");
            
            _logger.Debug("Got {A} segments in {B}ms", 
                inboundResult.StopPointSequences.Count, 
                watch.ElapsedMilliseconds);
            totalMs += watch.ElapsedMilliseconds;
            
            using (FileStream fs = new($"{lp}_inbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, inboundResult);
            }
            
            _progressCallback(InitialPercent + PercentOfTotal * (idx+0.5)
                / (double)rawLines.Count);
            
            // Process outbound route segments separately as graph is directed
            _logger.Debug("Processing outbound segments for line {A}", cid);
            watch.Restart();
            
            var outboundResult = _lineApi.LineRouteSequence(cid, "outbound");
            
            _logger.Debug("Got {A} segments in {B}ms", 
                inboundResult.StopPointSequences.Count, 
                watch.ElapsedMilliseconds);
            totalMs += watch.ElapsedMilliseconds;

            using (FileStream fs = new($"{lp}_outbound.xml", FileMode.Create))
            {
                serializer.WriteObject(fs, outboundResult);
            }
        }
        
        _logger.Debug("Total time taken for line fetch: {A}ms", totalMs);
        
        // Update the timings too
        UpdateTimingsLib();
        
        // Write to a metadata file so we know when the cache was updated
        using (FileStream fs = new($"{_cachePath}lastUpdated.txt", FileMode.Create))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now.ToString());
            }
        }

        _progressCallback(InitialPercent + PercentOfTotal);
    }

    // Download the file with timings data from the repo
    private void UpdateTimingsLib()
    {
        const string address = "https://raw.githubusercontent.com/Liftyee/tube-timings/main/data.txt";
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(address, $"{_cachePath}timingsData.txt");
        }
    }
    
    // Populate the network with the timings data from the timings file
    private void PopulateNetworkTimesTimingsLib(ref Network network)
    {
        _logger.Debug("Populating network times from timings file...");
        using (StreamReader dataFile = File.OpenText($"{_cachePath}timingsData.txt"))
        {
            while (!dataFile.EndOfStream)
            {
                // Each line is the cost of an edge
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
                    network.LinkStationsPartial(edgeDetails[0], edgeDetails[1], Dir.Bidirectional, null);
                    network.UpdateLink(edgeDetails[0], edgeDetails[1], new TimeSpan(0, minutes, seconds));
                }
            }
        }
    }
}
