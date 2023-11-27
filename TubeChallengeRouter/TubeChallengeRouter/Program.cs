using System;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using System.Linq;

namespace TubeChallengeRouter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}