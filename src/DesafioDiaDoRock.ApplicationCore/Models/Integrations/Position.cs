namespace DesafioDiaDoRock.ApplicationCore.Models.Integrations
{
    public class Position
    {
        public Position(decimal lat, decimal lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
