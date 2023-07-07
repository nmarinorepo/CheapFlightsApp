using System.ComponentModel.DataAnnotations;

namespace CheapFlights.Application.Models
{
    public class RetrieveBookingRq
    {
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string BookingId { get; set; }
        
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
