namespace TransportNetwork;

public class Station
{
    // some attributes internal so that data fetchers can update values after instantiation
    public readonly string? Name;
    private HashSet<Link> _links;
    public readonly string NaptanId;

    public Station(string naptan)
    {
        NaptanId = naptan;
        _links = new HashSet<Link>();
    }
    
    public Station(string naptan, string name) : this(naptan)
    {
        Name = name;
    }

    public void AddLink(Link newLink)
    {
        _links.Add(newLink);
    } 
    
    public List<Link> GetLinks()
    {
        return this._links.ToList();
    }

    // Cost function to a destination station.
    public int CostTo(string destId)
    {
        return this.GetLinkByDestId(destId).GetCost();
    }

    // NOTE: Can't use a dictionary for storing links, because the link destinations are not unique!
    // Predicate for checking if a link to a given destination exists
    public bool HasLink(string destId)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destId)
            {
                return true;
            }
        }

        return false;
    }

    // Return link object for a given destination station ID
    internal Link GetLinkByDestId(string id)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == id)
            {
                return link;
            }
        }

        throw new ArgumentException($"No link found with ID {id}");
    }
    
    // Modify the duration of an existing link on a given line to a given destination
    public void ModifyLink(string lineId, string destId, TimeSpan newTime)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destId && link.Line?.Id == lineId)
            {
                link.SetDuration(newTime);
                return; // only one link should match
            }
        }

        throw new ArgumentException($"No link found with ID {destId} on line {lineId}");
    }
    
    // Modify the duration of an existing link with given destination, on any line
    public void ModifyLink(string destId, TimeSpan newTime)
    {
        bool matched = false;
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destId)
            {
                matched = true;
                link.SetDuration(newTime);
                // many links might match, so don't return here
            }
        }

        if (!matched) throw new ArgumentException($"No link found with ID {destId}");
    }
}