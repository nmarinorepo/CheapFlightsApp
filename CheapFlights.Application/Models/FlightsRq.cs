namespace CheapFlights.Application.Models
{
    public class FlightsRq
    {
        public DateTimeOffset FlightDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public ICollection<Paxtype> PaxType { get; set; }
    }
}
