namespace DesafioDiaDoRock.ApplicationCore.Entities;

public class Event
{
    private Event() {}

    public Event(int id, string band, DateTime date, string nameLocation, string address, decimal latitude, decimal longitude, string urlImage)
    {
        Id = id;
        Band = band;
        Date = date;
        NameLocation = nameLocation;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        UrlImage = urlImage;
    }

    public int Id { get; set; }
    public string Band { get; set; }
    public DateTime Date { get; set; }
    public string NameLocation { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string UrlImage { get; set; }
}
