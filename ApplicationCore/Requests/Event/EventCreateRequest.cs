namespace DesafioDiaDoRock.ApplicationCore.Requests.Event
{
    public class EventCreateRequest
    {
        public int Id { get; set; }
        public string Band { get; set; }
        public DateTime Date { get; set; }
        public string NameLocation { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string UrlImage { get; set; }
    }
}
