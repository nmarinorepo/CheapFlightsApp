using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Utilities
{
    internal class CustomValidator
    {
        public static bool isValidBooking(BookingRqEntity bookingRqEntity)
        {
            //Validation flight date not expired;
            DateTime now = DateTime.UtcNow;
            DateTimeOffset flightDate = bookingRqEntity.FlightDate.UtcDateTime;

            TimeSpan diff = flightDate - now;
            if(diff <= TimeSpan.Zero) 
            {
                return false;
            }

            //Validation at least an adult with a child
            if (bookingRqEntity.Passengers.Any(p => p.PaxType.Equals("CHD")))
            {
                return bookingRqEntity.Passengers.Any(p => p.PaxType.Equals("ADT"));
            }

            return true;
        }
    }
}
