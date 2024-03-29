using System.Diagnostics;
using System.Text;
using Serilog;

namespace TransportNetwork;

public class FloydCostNetwork : Network
{
    private Dictionary<string, Dictionary<string, int>> _costMatrix; // format: [start station][end station]

    public FloydCostNetwork(ILogger logger) : base(logger)
    {
        _costMatrix = new Dictionary<string, Dictionary<string, int>>();
    }
    
    // Override the initialise method run by the NetworkFactory class
    internal override void Initialise()
    {
        PreprocessFloyd();
    }

    // Dijkstra's algorithm turned out to be fine so this isn't supported
    public override int CostFunction(string startId, string endId, out List<string> path)
    {
        throw new NotSupportedException("Floyd cost function network does not support intermediate path tracking");
    }

    // Cost function is just a lookup in the cost matrix
    public override int CostFunction(string startId, string endId)
    {
        return _costMatrix[startId][endId];
    }
    
    // Use the Floyd-Warshall algorithm to preprocess the cost matrix
    private void PreprocessFloyd()
    {
        Logger.Information("Preprocessing Floyd-Warshall weights...");
        
        // Initialise cost matrix with infinities/zeroes to the same station
        foreach (string stationId in Stations.Keys)
        {
            _costMatrix[stationId] = new Dictionary<string, int>();
            foreach (string station2Id in Stations.Keys)
            {
                if (stationId != station2Id)
                {
                    _costMatrix[stationId][station2Id] = InfCost;
                }
                else
                {
                    // station has no cost to itself
                    _costMatrix[stationId][station2Id] = 0; 
                }
            }
        }
        Logger.Debug("Cost matrix initialised");
        
        // populate cost matrix with weights of links for each station
        foreach (Station station in Stations.Values)
        {
            foreach (Link link in station.GetLinks())
            {
                _costMatrix[station.NaptanId][link.Destination.NaptanId] = (int)link.Duration.TotalSeconds;
            }
        }
        Logger.Debug("Links populated");
        
        // track algo performance
        Stopwatch timer = new Stopwatch();
        timer.Start();
        int nIterations = 0;
        
        // run Floyd-Warshall
        foreach (string k in Stations.Keys)
        {
            foreach (string i in Stations.Keys)
            {
                foreach (string j in Stations.Keys)
                {
                    // NOTE: the right side of this comparison is prone to overflowing!
                    if (_costMatrix[i][j] > (_costMatrix[i][k] + _costMatrix[k][j]))
                    {
                        _costMatrix[i][j] = _costMatrix[i][k] + _costMatrix[k][j];
                        if (_costMatrix[i][j] < 0)
                        {
                            Logger.Fatal("Tried to set negative cost between {A} and {B} ({C})", i, j, _costMatrix[i][j]);
                            throw new OverflowException($"Overflow when calculating cost between {i} and {j} via {k}! {_costMatrix[i][j]}");
                        }
                    }

                    nIterations++;
                }
            }
        }

        // only print the cost matrix into debug if it's small enough
        if (Stations.Count <= 10)
        {
            Logger.Debug(EnumerateCostMatrix());
        }
        
        Logger.Information("Done! Took {A}ms ({B} iterations)", timer.ElapsedMilliseconds, nIterations);
    }
    
    public string EnumerateCostMatrix()
    {
        StringBuilder output = new StringBuilder();
        foreach (string stationId in Stations.Keys)
        {
            output.Append($"Station {stationId} has cost matrix: ");
            foreach (string station2Id in Stations.Keys)
            {
                output.Append($"{station2Id} ({_costMatrix[stationId][station2Id]}), ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }
}