using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Interfaces
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<IEnumerable<Flight>> GetFlights();

        Task<IEnumerable<Flight>> GetFlightsByParams(FlightsRq flightSearch);

        Task<Flight> GetFlightByKey(BookingRq bookingRq);
    }
}
