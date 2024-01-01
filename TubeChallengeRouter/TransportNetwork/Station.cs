namespace TransportNetwork;

public class Station
{
    // some attributes internal so that data fetchers can update values after instantiation
    internal string? Name;
    internal List<Line>? Lines;
    private List<Link> _links;
    public readonly string NaptanId;

    public Station(string naptan)
    {
        NaptanId = naptan;
        _links = new List<Link>();
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
        return this._links;
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

    public Link GetLinkById(string Id)
    {
        foreach (Link link in _links)
        {
            if (link.Destination.NaptanId == Id)
            {
                return link;
            }
        }

        throw new Exception($"No link found with ID {Id}");
    }
}