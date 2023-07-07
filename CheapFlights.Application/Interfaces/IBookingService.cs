using CheapFlights.Application.Models;

namespace CheapFlights.Application.Interfaces
{
    public interface IBookingService
    {
        BookingRs CreateBooking(BookingRq bookingRq);

        BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq);
    }
}
