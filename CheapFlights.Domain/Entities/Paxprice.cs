using CheapFlights.Domain.Common;

namespace CheapFlights.Domain.Entities
{
    public class Paxprice : BaseEntity
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
