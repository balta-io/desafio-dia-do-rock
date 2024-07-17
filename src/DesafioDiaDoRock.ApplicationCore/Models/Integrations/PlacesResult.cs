namespace DesafioDiaDoRock.ApplicationCore.Models.Integrations;

public class PlacesResult
{
    public Place[] places { get; set; } = [];
}

public class Place
{
    public string formattedAddress { get; set; } = null!;
    public Location location { get; set; } = new();
    public Displayname displayName { get; set; } = new();
}

public class Location
{
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
}

public class Displayname
{
    public string text { get; set; } = null!;
    public string languageCode { get; set; } = null!;
}
