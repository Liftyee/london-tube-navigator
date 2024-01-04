namespace TransportNetwork;

public class Station
{
    // some attributes internal so that data fetchers can update values after instantiation
    public readonly string? Name;
    internal List<Line>? Lines;
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

    public int CostTo(string destID)
    {
        return this.GetLinkByDestId(destID).GetCost();
    }

    // NOTE: Can't use a dictionary, because the link destinations are not unique!
    public bool HasLink(string destID)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destID)
            {
                return true;
            }
        }

        return false;
    }

    public Link GetLinkByDestId(string Id)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == Id)
            {
                return link;
            }
        }

        throw new ArgumentException($"No link found with ID {Id}");
    }
    
    public void ModifyLink(string lineID, string destID, TimeSpan newTime)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destID && link.Line?.Id == lineID)
            {
                link.SetDuration(newTime);
                return; // only one link should match
            }
        }

        throw new ArgumentException($"No link found with ID {destID} on line {lineID}");
    }
    
    public void ModifyLink(string destID, TimeSpan newTime)
    {
        bool matched = false;
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == destID)
            {
                matched = true;
                link.SetDuration(newTime);
                // many links might match, don't return
            }
        }

        if (!matched) throw new ArgumentException($"No link found with ID {destID}");
    }
}