using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using TransportNetwork;

namespace TubeChallengeRouter
{
    internal class Program
    {
        private static Network tube;
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            tube = new Network();
            TestAPI();
        }

        private static void TestAPI()
        {
            var apiconfig = new Configuration();
            apiconfig.BasePath = "https://api.tfl.gov.uk";
            var lineApi = new LineApi(apiconfig);
            List<string> lines = new List<string>{"piccadilly", "northern"};
            List<TflApiPresentationEntitiesLine> result = lineApi.LineGet(lines);
            
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"Line {i}: {result[i].Name}");
                List<TflApiPresentationEntitiesStopPoint> stations = lineApi.LineStopPoints(result[i].Id);
                Console.WriteLine($"Stations: {string.Join(", ", stations.Select((item, index) => $"{item.CommonName}"))}");
            }
        }

        struct LineEdge
        {
            public readonly string PointA;
            public readonly string PointB;
            public readonly double DurationMins;

            public LineEdge(string pointA, string pointB, double durationMins)
            {
                PointA = pointA;
                PointB = pointB;
                DurationMins = durationMins;
            }
        }

        private static void PopulateNetwork(List<LineEdge> edges)
        {
            foreach (LineEdge e in edges)
            {
                // convert from decimal minutes into TimeSpan object   
                TimeSpan duration = new TimeSpan(hours: 0, (int)Math.Floor(e.DurationMins),
                    (int)Math.Floor((e.DurationMins % 1) * 60));

                tube.LinkStations(new Station(e.PointA), new Station(e.PointB), duration);
            }
        }

        private static LineEdge EdgeObjectFromDetails(string[] edgeData)
        {
            if (edgeData.Length != 3)
            {
                throw new ArgumentException(
                    $"Invalid edge details array: {edgeData.ToString} has {edgeData.Length} items");
            }

            return new LineEdge(edgeData[0], edgeData[1], System.Convert.ToDouble(edgeData[2]));
        }

        private static void ImportLondonTubeData()
        {
            using (StreamReader dataFile = File.OpenText("data.txt"))
            {
                List<LineEdge> edgeObjects = new();
                while (!dataFile.EndOfStream) 
                {
                    // parse line by line
                    string rawLine = dataFile.ReadLine();
                    string[] edgeDetails = rawLine.Split(" ");
                    edgeObjects.Add(EdgeObjectFromDetails(edgeDetails));
                }
                PopulateNetwork(edgeObjects);
            }
        }
    }
}