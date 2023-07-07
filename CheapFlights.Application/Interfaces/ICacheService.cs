using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Interfaces
{
    public interface ICacheService
    {
        void CreateBooking(BookingRqEntity bookingRs);

        BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq);
    }
}
