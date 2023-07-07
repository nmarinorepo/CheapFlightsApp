using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.Models
{
    public class BookingRq
    {
        [Required]
        public string FlightKey { get; set; }
        [MinLength(1)]
        public ICollection<Passenger> Passengers { get; set; }
        [Required]
        public Contact Contact { get; set; }
    }

    public class Passenger
    {
        [Required]
        public string FirstNamePax { get; set; }
        [Required]
        public string LastNamePax { get; set; }
        [Required]
        public DateTime DateOfBirthPax { get; set; }
    }

    public class Contact
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
