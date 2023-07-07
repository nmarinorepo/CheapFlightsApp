using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Interfaces
{
    public interface ICacheRepository
    {
        public void CreateBooking(string key, BookingRqEntity bookingRqEntity);

        public BookingRs RetrieveBooking(string key);
    }
}
