using System.Diagnostics;
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
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information("Hello World! Logging is {Description}.","online");

            TestTubeGen();
            Console.ReadKey();
            LinearNetworkTestRouting();
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
            Network tube = tubeFactory.Generate(NetworkType.Floyd, logger);
            logger.Information("Result: {A}",tube.ToString());
            //logger.Debug(tube.EnumerateStations());

            ISolver solver = new AnnealingSolver(logger);
            IRoute route = solver.Solve(tube);
            logger.Information("Route: {A} (duration {B})",tube.RouteToStringStationSeq(route), route.Duration());
        }
        
        private static void LinearNetworkTestRouting()
        {
            // create a simple linear network of 10 stations
            NetworkFactory linearFactory = new NetworkFactory(new LinearNetwork(10));
            Network net = linearFactory.Generate(NetworkType.Floyd, logger);
            logger.Information("Result: {A}",net.ToString());
            // logger.Debug(tube.EnumerateStations());
            
            ISolver solver = new AnnealingSolver(logger);
            IRoute route = solver.Solve(net);
        }
        
        struct LineEdge
        {
            public readonly string PointA;
            public readonly string PointB;
            public readonly double DurationMins;
            public readonly bool Directed;

            public LineEdge(string pointA, string pointB, double durationMins, bool directed=false)
            {
                PointA = pointA;
                PointB = pointB;
                DurationMins = durationMins;
                Directed = directed;
            }
        }

        private static void PopulateNetwork(List<LineEdge> edges, Network tube)
        {
            foreach (LineEdge e in edges)
            {
                // convert from decimal minutes into TimeSpan object   
                TimeSpan duration = new TimeSpan(hours: 0, (int)Math.Floor(e.DurationMins),
                    (int)Math.Floor((e.DurationMins % 1) * 60));
                
                if (!tube.HasStationByID(e.PointA))
                {
                    tube.AddStation(new Station(e.PointA));
                }
                
                if (!tube.HasStationByID(e.PointB))
                {
                    tube.AddStation(new Station(e.PointB));
                }
                
                tube.LinkStations(e.PointA, e.PointB, duration, e.Directed); // Respect directivity
            }
        }

        private static LineEdge EdgeObjectFromDetails(string[] edgeData)
        {
            if (edgeData.Length != 3)
            {
                throw new ArgumentException(
                    $"Invalid edge details array: {edgeData.ToString} has {edgeData.Length} items");
            }
            // assume data contains directed edges
            return new LineEdge(edgeData[0], edgeData[1], System.Convert.ToDouble(edgeData[2]), true);
        }

        private static void ImportLondonTubeData(Network tube)
        {
            using (StreamReader dataFile = File.OpenText("/home/yee/RiderProjects/tube-challenge-router/tube-timings/data.txt"))
            {
                List<LineEdge> edgeObjects = new();
                while (!dataFile.EndOfStream) 
                {
                    // parse line by line
                    string rawLine = dataFile.ReadLine();
                    string[] edgeDetails = rawLine.Split(" ");
                    edgeObjects.Add(EdgeObjectFromDetails(edgeDetails));
                }
                PopulateNetwork(edgeObjects, tube);
            }
        }
    }
}