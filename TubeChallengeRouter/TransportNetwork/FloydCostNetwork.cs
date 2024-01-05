using System.Diagnostics;
using System.Text;
using Serilog;

namespace TransportNetwork;

public class FloydCostNetwork : Network
{
    private Dictionary<string, Dictionary<string, int>> _costMatrix; // format: [start station][end station]

    public FloydCostNetwork(ILogger logger) : base(logger)
    {
        
    }
    
    internal override void Initialise()
    {
        PreprocessFloyd();
    }
    public override int CostFunction(string startId, string endId, List<string>? lineIDs=null)
    {
        return _costMatrix[startId][endId];
    }
    
    private void PreprocessFloyd()
    {
        Logger.Information("Preprocessing Floyd-Warshall weights...");
        
        // initialise cost matrix
        _costMatrix = new Dictionary<string, Dictionary<string, int>>();
        foreach (string stationID in Stations.Keys)
        {
            _costMatrix[stationID] = new Dictionary<string, int>();
            foreach (string station2ID in Stations.Keys)
            {
                if (stationID != station2ID)
                {
                    _costMatrix[stationID][station2ID] = INF_COST;
                }
                else
                {
                    _costMatrix[stationID][station2ID] = 0; // station has no cost to itself
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
        foreach (string stationID in Stations.Keys)
        {
            output.Append($"Station {stationID} has cost matrix: ");
            foreach (string station2ID in Stations.Keys)
            {
                output.Append($"{station2ID} ({_costMatrix[stationID][station2ID]}), ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }
}