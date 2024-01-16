using System.Diagnostics;
using System.Text;
using DataFetcher;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using NUnit.Framework.Constraints;
using TransportNetwork;
using Serilog;
using DataFetcher;
using Eto.Forms;
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
        
        private static void TestAPI()
        {
            var apiconfig = new Configuration();
            apiconfig.BasePath = "https://api.tfl.gov.uk";
            var lineApi = new LineApi(apiconfig);

            logger.Debug("Fetching all tube lines...");
            var rawLines = lineApi.LineGetByMode(new List<string> { "tube" });
            
            List<string> lineIds = new List<string>();
            foreach (var l in rawLines)
            {
                lineIds.Add(l.Id);
            }
            logger.Information($"Found lines: {string.Join(", ", lineIds)}");
            
            for (int i = 0; i < lineIds.Count; i++)
            {
                logger.Debug($"Line {i}: {lineIds[i]}");
                var lineStationSequences = lineApi.LineRouteSequence(lineIds[i],"inbound");
                logger.Debug($"{lineStationSequences.StopPointSequences.Count} station segments found");
                for (int j = 0; j < lineStationSequences.StopPointSequences.Count; j++)
                {
                    logger.Debug($"Segment {j}: {lineStationSequences.StopPointSequences[j].StopPoint[0].Name} to {lineStationSequences.StopPointSequences[j].StopPoint.Last().Name}");
                }
            }
        }
        private static void TestTubeGen()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger));
            Network tube = tubeFactory.Generate(NetworkType.Dijkstra, logger);
            logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(logger);
            Route route = solver.Solve(tube);
            logger.Debug("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration);
            
            // write route to a file
            using (var file = new System.IO.FileStream("route.txt", System.IO.FileMode.Create))
            {
                tube.RouteDetailsToStream(route, file);
            }
        }

        private static void WriteStationsToFile()
        {
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger));
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
            NetworkFactory tubeFactory = new NetworkFactory(new TflModelWrapper(logger));
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
    }
}