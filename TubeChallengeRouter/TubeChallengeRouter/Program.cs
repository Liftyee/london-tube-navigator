using System.Diagnostics;
using DataFetcher;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using NUnit.Framework.Constraints;
using TransportNetwork;
using Serilog;
using DataFetcher;

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
        }
        
        private static void LinearNetworkTestRouting()
        {
            // create a simple linear network of 10 stations
            NetworkFactory linearFactory = new NetworkFactory(new LinearNetwork(10));
            Network net = linearFactory.Generate(NetworkType.Floyd, logger);
            logger.Information("Result: {A}",net.ToString());
            // logger.Debug(tube.EnumerateStations());
            
            // generate a random route
            IRoute route = net.GenerateRandomRoute();
            logger.Debug("Random route: {A}",route.ToString());

            Debug.Assert(route.Duration().TotalMinutes == net.CostFunction(route));
            
            const int tempStepIterations = 100;
            const int maxIterations = 10000;
            const double coolDownFactor = 0.9;
            const int noChangeThreshold = 100;
            double Temperature = 10000;
            int randomA, randomB, oldCost, newCost;
            int loopsSinceLastAccept = 0;
            var randomGenerator = new Random();
            // TODO: add simulated annealing magic
            for (int i = 1; i < maxIterations; i++)
            {
                // pick a random pair of stations to swap
                do
                {
                    randomA = randomGenerator.Next(0, route.Count());
                    randomB = randomGenerator.Next(0, route.Count());
                } while (randomA == randomB);

                oldCost = net.CostFunction(route);
                route.Swap(randomA, randomB);
                newCost = net.CostFunction(route);

                if (newCost < oldCost)
                {
                    // accept the change
                    loopsSinceLastAccept = 0;
                }
                else
                {
                    // accept the change with probability e^(-delta/T)
                    double delta = oldCost - newCost;
                    double probability = Math.Exp(delta / Temperature);
                    if (randomGenerator.NextDouble() < probability)
                    {
                        loopsSinceLastAccept = 0;
                    }
                    else
                    {
                        // reject the change (swap back)
                        route.Swap(randomA, randomB);
                        loopsSinceLastAccept++;
                    }
                }
                
                // cool down every tempStepIterations cycles
                if (i % tempStepIterations == 0)
                {
                    Temperature *= coolDownFactor;
                    
                    logger.Debug("Cooled down to {A}",Temperature);
                    logger.Debug("Current route: {A}",route.ToString());
                }
                
                // if we haven't changed anything for a while then we're probably done
                if (loopsSinceLastAccept > noChangeThreshold)
                {
                    logger.Debug("No change for {A} iterations, stopping annealing",loopsSinceLastAccept);
                    break;
                }
            }
            logger.Debug("Final route: {A}",route.ToString());
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