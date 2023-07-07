using CheapFlights.Domain.Common;

namespace CheapFlights.Domain.Entities
{
    public class Flight : BaseEntity
    {
        public string FlightKey { get; set; }
        public string FlightNumber { get; set; }
        public DateTimeOffset FlightDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public ICollection<Paxprice> PaxPrice { get; set; }
    }
}
