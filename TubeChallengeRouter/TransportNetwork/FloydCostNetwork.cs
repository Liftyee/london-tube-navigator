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
    public override int CostFunction(string startId, string endId)
    {
        return _costMatrix[startId][endId];
    }
    
    private void PreprocessFloyd()
    {
        logger.Information("Preprocessing Floyd-Warshall weights...");
        
        // initialise cost matrix
        _costMatrix = new Dictionary<string, Dictionary<string, int>>();
        foreach (string stationID in _stations.Keys)
        {
            _costMatrix[stationID] = new Dictionary<string, int>();
            foreach (string station2ID in _stations.Keys)
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
        logger.Debug("Cost matrix initialised");
        
        // populate cost matrix with weights of links for each station
        foreach (Station station in _stations.Values)
        {
            foreach (Link link in station.GetLinks())
            {
                _costMatrix[station.NaptanId][link.Destination.NaptanId] = (int)link.Duration.Value.TotalMinutes;
            }
        }
        logger.Debug("Links populated");
        
        // track algo performance
        Stopwatch timer = new Stopwatch();
        timer.Start();
        int nIterations = 0;
        
        // run Floyd-Warshall
        foreach (string k in _stations.Keys)
        {
            foreach (string i in _stations.Keys)
            {
                foreach (string j in _stations.Keys)
                {
                    // NOTE: the right side of this comparison is prone to overflowing!
                    if (_costMatrix[i][j] > (_costMatrix[i][k] + _costMatrix[k][j]))
                    {
                        _costMatrix[i][j] = _costMatrix[i][k] + _costMatrix[k][j];
                        if (_costMatrix[i][j] < 0)
                        {
                            logger.Fatal("Tried to set negative cost between {A} and {B} ({C})", i, j, _costMatrix[i][j]);
                            throw new OverflowException($"Overflow when calculating cost between {i} and {j} via {k}! {_costMatrix[i][j]}");
                        }
                    }

                    nIterations++;
                }
            }
        }

        // only print the cost matrix into debug if it's small enough
        if (_stations.Count <= 10)
        {
            logger.Debug(EnumerateCostMatrix());
        }
        
        logger.Information("Done! Took {A}ms ({B} iterations)", timer.ElapsedMilliseconds, nIterations);
    }
    
    public string EnumerateCostMatrix()
    {
        StringBuilder output = new StringBuilder();
        foreach (string stationID in _stations.Keys)
        {
            output.Append($"Station {stationID} has cost matrix: ");
            foreach (string station2ID in _stations.Keys)
            {
                output.Append($"{station2ID} ({_costMatrix[stationID][station2ID]}), ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }
}