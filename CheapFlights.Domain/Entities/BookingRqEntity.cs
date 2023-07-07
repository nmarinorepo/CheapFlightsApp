namespace CheapFlights.Domain.Entities
{

    public class BookingRqEntity
    {
        public DateTimeOffset FlightDate { get; set; }
        public string FlightKey { get; set; }
        public string FlightNumber { get; set; }
        public ICollection<PassengerEntity> Passengers { get; set; }

        public ContactEntity Contact { get; set; }

        public DateTime BookingDate { get; set; }
        public string BookingId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

        public decimal TotalPrice { get; set; }
    }

    public class PassengerEntity
    {
        public string FirstNamePax { get; set; }
        public string LastNamePax { get; set; }
        public DateTime DateOfBirthPax { get; set; }
        public string PaxType { get; set; }
    }

    public class ContactEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
