using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Interfaces
{
    public interface IFlightsService
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<IEnumerable<Flight>> GetFlightsByParams(FlightsRq flightsRq);
    }
}
