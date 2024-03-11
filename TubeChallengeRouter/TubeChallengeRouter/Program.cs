using DataFetcher;
using TransportNetwork;
using Serilog;
using RouteSolver;

namespace TubeChallengeRouter
{
    internal class Program
    {
        private static ILogger _logger;
        private static void Main(string[] args)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
            _logger.Information("Hello World! Logging is {Description}.","online");

            TestTubeGen();
            //TestTubeGenFloyd();
        }
        
        private static void TestTubeGen()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(_logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Dijkstra, _logger);
            _logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(_logger);
            Route route = solver.Solve(tube);
            _logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);

            // TODO: extract this output code to a function
            var now = DateTime.Now;
            string datecode = $"{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}";
            string outputpath = $"{GetCachePath()}route{datecode}.txt";
            // write route to a file
            using (var file = new FileStream(outputpath, FileMode.Create))
            {
                tube.RouteDetailsToStream(route, file);
                _logger.Information("Result written to {A}", outputpath);
            }
        }

        private static void WriteStationsToFile()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(_logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Simple, _logger);
            
            using (FileStream file = new FileStream("stations.txt", System.IO.FileMode.Create))
            {
                tube.WriteStationsToFile(file);
            }
        }
        
        private static void TestTubeGenFloyd()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(_logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Floyd, _logger);
            _logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(_logger);
            Route route = solver.Solve(tube);
            _logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);
        }
        
        private static void LinearNetworkTestRouting()
        {
            // create a simple linear network of 10 stations
            NetworkFactory linearFactory = new NetworkFactory(new LinearNetwork(10));
            Network net = linearFactory.Generate(NetworkType.Floyd, _logger);
            _logger.Information("Result: {A}",net.ToString());
            // logger.Debug(tube.EnumerateStations());
            
            ISolver solver = new AnnealingSolver(_logger);
            Route route = solver.Solve(net);
        }

        private static string GetCachePath()
        {
            // work out the cache path in a platform-agnostic way
            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            const string furtherPath = ".cache/TubeNetworkCache/"; // Linux standard but works for Windows too
            return Path.Combine(homeDir, furtherPath);
        }
    }
}