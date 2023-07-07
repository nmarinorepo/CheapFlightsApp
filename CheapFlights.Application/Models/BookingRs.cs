namespace CheapFlights.Application.Models
{
    public class BookingRs
    {
        public DateTimeOffset FlightDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public ICollection<PassengerRs> Passengers { get; set; }
        public Contact Contact { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingId { get; set; }
        public float TotalPrice { get; set; }
    }

    public class PassengerRs
    {
        public string FirstNamePax { get; set; }
        public string LastNamePax { get; set; }
        public DateTime DateOfBirthPax { get; set; }
    }
}
