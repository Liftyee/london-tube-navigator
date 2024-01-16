using System.Text;
using DataFetcher;
using TransportNetwork;
using Serilog;
using RouteSolver;

namespace TubeChallengeRouter
{
    internal class Program
    {
        private static ILogger logger;
        private static void Main(string[] args)
        {
            logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information("Hello World! Logging is {Description}.","online");

            TestTubeGen();
            //TestTubeGenFloyd();
        }
        
        private static void TestTubeGen()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Dijkstra, logger);
            logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(logger);
            Route route = solver.Solve(tube);
            logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);

            // TODO: extract this output code to a function
            var now = DateTime.Now;
            string datecode = $"{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}";
            string outputpath = $"{GetCachePath()}route{datecode}.txt";
            // write route to a file
            using (var file = new FileStream(outputpath, FileMode.Create))
            {
                tube.RouteDetailsToStream(route, file);
                logger.Information("Result written to {A}", outputpath);
            }
        }

        private static void WriteStationsToFile()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Simple, logger);
            
            using (FileStream file = new FileStream("stations.txt", System.IO.FileMode.Create))
            {
                foreach (var station in tube.GetStations())
                {
                    file.Write(Encoding.UTF8.GetBytes($"{station.NaptanId}:{station.Name.Replace(" Underground Station", "")}\n"));
                }
            }
        }
        
        private static void TestTubeGenFloyd()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger, GetCachePath()));
            Network tube = tubeFactory.Generate(NetworkType.Floyd, logger);
            logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(logger);
            Route route = solver.Solve(tube);
            logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);
        }
        
        private static void LinearNetworkTestRouting()
        {
            // create a simple linear network of 10 stations
            NetworkFactory linearFactory = new NetworkFactory(new LinearNetwork(10));
            Network net = linearFactory.Generate(NetworkType.Floyd, logger);
            logger.Information("Result: {A}",net.ToString());
            // logger.Debug(tube.EnumerateStations());
            
            ISolver solver = new AnnealingSolver(logger);
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