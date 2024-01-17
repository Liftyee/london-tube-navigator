using System.Text;
namespace TransportNetwork;
using Serilog;

[Serializable]
public class Network
{
    protected Dictionary<string, Station> Stations;
    protected Dictionary<int, Line> Lines;
    protected ILogger Logger;
    protected const int INF_COST = 1000000000; // use 1 billion instead of MaxValue to avoid overflow issues
    public int StationCount => Stations.Count;
    protected int NEdges;
    
    public Network(ILogger logger)
    {
        this.Logger = logger;
        Stations = new Dictionary<string, Station>();
        Lines = new Dictionary<int, Line>();
    }

    internal virtual void Initialise()
    {
        
    }

    public void AddStation(Station stationToAdd)
    {
        Stations.Add(stationToAdd.NaptanId, stationToAdd);
    }

    public void AddStationByIdIfNotPresent(string naptanId)
    {
        if (!this.HasStationById(naptanId))
        {
            this.AddStation(new Station(naptanId));
        }
    }

    public void AddStationByIdIfNotPresent(string naptanId, string name)
    {
        if (!this.HasStationById(naptanId))
        {
            this.AddStation(new Station(naptanId, name));
        }
    }
    
    public void LinkStationsPartial(string startId, string endId, Dir direction, Line? line=null)
    {
        Station startStation = Stations[startId];
        Station endStation = Stations[endId];

        if (direction == Dir.Bidirectional)
        {
            startStation.AddLink(new Link(startStation, endStation, line, direction));
            endStation.AddLink(new Link(endStation, startStation, line, direction));
        } else {
            startStation.AddLink(new Link(startStation, endStation, line, direction));
        }
        
        NEdges++;
    }
    
    public void UpdateLink(string startId, string endId, TimeSpan newTime)
    {
        Station startStation = Stations[startId];
        startStation.ModifyLink(endId, newTime);
    }

    public bool HasStationById(string ID)
    {
        return Stations.Keys.Contains(ID);
    }
    
    public override string ToString()
    {
        return $"Network with {Stations.Count} stations and {Lines.Count} lines ({NEdges} directed edges)";
    }

    public string EnumerateStations()
    {
        // output each station and its links
        StringBuilder output = new StringBuilder();
        foreach (KeyValuePair<string, Station> station in Stations)
        {
            output.Append($"Station {station.Key} has links to: ");
            foreach (Link link in station.Value.GetLinks())
            {
                output.Append($"{link.Destination.NaptanId} ({link.Duration.ToString()}) {link.Dir.ToString()}, ");
            }

            output.Append("\n");
        }

        return output.ToString();
    }
    
    public List<Station> GetStations()
    {
        return Stations.Values.ToList();
    }

    public virtual int CostFunction(string startId, string endId, out List<string> path)
    {
        throw new InvalidOperationException("Simple network doesn't support cost function with path (use overrides)");
    }

    public virtual int CostFunction(string startId, string endId)
    {
        if (Stations[startId].HasLink(endId))
        {
            return (int)Stations[startId].GetLinkByDestId(endId).Duration.TotalSeconds;
        }
        else
        {
            throw new ArgumentException("Simple network doesn't support cost function for non-linked stations (use overrides)");
        }
    }

    // generate random route through all stations
    public virtual Route GenerateRandomRoute()
    {
        List<string> stationIDs = new List<string>(); 
        HashSet<string> visitedIDs = new HashSet<string>();
        int totalCost = 0;
        List<List<string>> intermediateStations = new List<List<string>>();
        
        while (visitedIDs.Count < Stations.Count)
        {
            string nextID = Stations.Keys.ElementAt(new Random().Next(Stations.Count));
            if (!visitedIDs.Contains(nextID))
            {
                stationIDs.Add(nextID);
                visitedIDs.Add(nextID);
                List<string> pathToNext;
                if (visitedIDs.Count > 1)
                {
                    totalCost += CostFunction(stationIDs[^2], stationIDs[^1], out pathToNext);
                    intermediateStations.Add(pathToNext);
                }
            }
        }
        
        Route result = new Route(stationIDs, new TimeSpan(0, 0, totalCost), totalCost, intermediateStations);

        return result;
    }

    public virtual int CostFunction(Route route)
    {
        int cost = 0;
        List<string> routeStations = route.GetTargetPath();
        for (int i = 0; i < routeStations.Count - 1; i++)
        {
            cost += CostFunction(routeStations[i], routeStations[i+1]);
        }

        return cost;
    }

    public virtual TimeSpan TravelTime(Route route)
    {
        return new TimeSpan(0,0,CostFunction(route));
    }
    
    public virtual TimeSpan TravelTime(string startId, string endId)
    {
        return new TimeSpan(0,0,CostFunction(startId, endId));
    }

    // convert route naptan IDs into a string for readability
    public string RouteToStringStationSeq(Route route)
    {
        StringBuilder output = new StringBuilder();
        List<string> stationIDs = route.GetTargetPath();
        for (int i = 0; i < stationIDs.Count(); i++)
        {
            output.Append($"{Stations[stationIDs[i]].Name.Replace(" Underground Station", "")}, ");
        }

        return output.ToString();
    }

    public void RouteDetailsToStream(Route route, Stream outStream)
    {
        using (StreamWriter writer = new StreamWriter(outStream))
        {
            writer.WriteLine("Route result computed at " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ssZ"));
            writer.WriteLine($"Route with {route.Count} stations and length {route.Duration.TotalMinutes} minutes");
            
            List<string> stationIDs = route.GetTargetPath();
            List<List<string>> interStations = route.GetIntermediateStations();
            for (int i = 0; i < stationIDs.Count(); i++)
            {
                writer.WriteLine($"Visit: {Stations[stationIDs[i]].Name.Replace(" Underground Station", "")}");
                if (i < stationIDs.Count() - 1)
                {
                    writer.WriteLine(
                        $"Pass thru: {String.Join(", ", interStations[i].Select(s => Stations[s].Name.Replace(" Underground Station", "")))}");
                }
            }
            writer.WriteLine("Done");
        } 
    }

    protected virtual void RemoveStationFromTotals(ref Route route, int index)
    {
        List<string> stations = route.GetTargetPath();
        TimeSpan updatedTime = route.Duration;
        int updatedCost = route.Cost;

        if (index > 0)
        {
            updatedTime -= TravelTime(stations[index - 1], stations[index]);
            updatedCost -= CostFunction(stations[index - 1], stations[index]);
        }

        if (index < route.Count - 1)
        {
            updatedTime -= TravelTime(stations[index], stations[index + 1]);
            updatedCost -= CostFunction(stations[index], stations[index + 1]);
        }

        route.UpdateDuration(updatedTime);
        route.UpdateCost(updatedCost);
    }
    
    public virtual void Swap(Route route, int idxA, int idxB)
    {
        List<string> stations = route.GetTargetPath();
        
        TimeSpan updatedTime = route.Duration;
        int updatedCost = route.Cost;
        
        /* Instead of recalculating the travel time by summing all travel times between stations, we can just
           change the travel times to and from the stations that are being swapped. All other travel times should
           remain constant, so we are only concerned with what happens around our swapped stations. */
        
        // These four times are the time taken to travel to and from both stations being swapped (before the swap)
        if (idxA > 0)             updatedTime -= TravelTime(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedTime -= TravelTime(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedTime -= TravelTime(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedTime -= TravelTime(stations[idxB], stations[idxB + 1]);

        // Do the same for costs (unitless value considering but not limited to duration)
        if (idxA > 0)             updatedCost -= CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost -= CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost -= CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost -= CostFunction(stations[idxB], stations[idxB + 1]);
        
        // swap the stations in the route
        string temp = stations[idxA];
        stations[idxA] = stations[idxB];
        stations[idxB] = temp;
        
        // Now add the updated times to travel to and from the swapped stations in their new position
        if (idxA > 0)             updatedTime += TravelTime(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedTime += TravelTime(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedTime += TravelTime(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedTime += TravelTime(stations[idxB], stations[idxB + 1]);
        
        // and costs too
        if (idxA > 0)             updatedCost += CostFunction(stations[idxA - 1], stations[idxA]);
        if (idxA < route.Count-1) updatedCost += CostFunction(stations[idxA], stations[idxA + 1]);
        if (idxB > 0)             updatedCost += CostFunction(stations[idxB - 1], stations[idxB]);
        if (idxB < route.Count-1) updatedCost += CostFunction(stations[idxB], stations[idxB + 1]);
        
        // update the route's length (time taken)
        route.UpdateDuration(updatedTime);
        
        // update the route's cost (unitless value based on number of factors)
        route.UpdateCost(updatedCost);
    }
    
    // Remove a station from one position and insert it so that it ends up in another.
    // The final position will be one before the index of the element at insertBefore
    // i.e. the element that was at that index gets pushed back to insert the new one.
    public virtual void TakeAndInsert(Route route, int takeFrom, int insertBefore)
    {
        List<string> stations = route.GetTargetPath();

        TimeSpan updatedTime = route.Duration;
        int updatedCost = route.Cost;

        string station = route.TargetStations[takeFrom];
        
        // subtract travel cost to and from the station we are removing
        if (takeFrom > 0)
        {
            updatedTime -= TravelTime(stations[takeFrom - 1], stations[takeFrom]);
            updatedCost -= CostFunction(stations[takeFrom - 1], stations[takeFrom]);
        }

        if (takeFrom < route.Count - 1)
        {
            updatedTime -= TravelTime(stations[takeFrom], stations[takeFrom + 1]);
            updatedCost -= CostFunction(stations[takeFrom], stations[takeFrom + 1]);
        }
        
        // also subtract travel cost between the stations we will be inserting between, to get ready for insert
        if (insertBefore > 0)
        {
            updatedTime -= TravelTime(stations[insertBefore - 1], stations[insertBefore]);
            updatedCost -= CostFunction(stations[insertBefore - 1], stations[insertBefore]);
        }
        route.TargetStations.RemoveAt(takeFrom);
        
        // if the indices are the same, we might need to subtract
        // we should never be doing this anyways, so throw an exception
        if (insertBefore == takeFrom)
        {
            throw new InvalidOperationException("Why are you taking and reinserting at the same place?");
        }
        
        // if the index we are going to insert at is after the index we are removing from, we need to subtract one
        // so the final index in the array is between the elements we want TODO: rewrite this comment
        if (insertBefore > takeFrom)
        {
            insertBefore--;
        }

        route.TargetStations.Insert(insertBefore, station);
        
        // update our copy of the stations list 
        // stations = route.GetTargetPath(); (wait we don't need to??)
        // TODO: this is sus, is the unit test SwapInsert_UpdatesCost wrong?
        
        // add back the new travel cost to and from the station we inserted
        if (insertBefore > 0)
        {
            updatedTime += TravelTime(stations[insertBefore - 1], stations[insertBefore]);
            updatedCost += CostFunction(stations[insertBefore - 1], stations[insertBefore]);
        }
        
        if (insertBefore < route.Count-1)
        {
            updatedTime += TravelTime(stations[insertBefore], stations[insertBefore+1]);
            updatedCost += CostFunction(stations[insertBefore], stations[insertBefore+1]);
        }

        if (takeFrom > 0)
        {
            updatedTime += TravelTime(stations[takeFrom - 1], stations[takeFrom]);
            updatedCost += CostFunction(stations[takeFrom - 1], stations[takeFrom]);
        }
        
        route.UpdateDuration(updatedTime);
        route.UpdateCost(updatedCost);
    }

    public void RecalculateRouteCosts(ref Route route)
    {
        route.UpdateCost(CostFunction(route));
        route.UpdateDuration(TravelTime(route));
    }
}