using CheapFlight.Persistence.Data;
using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheapFlight.Persistence.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(FlightContext flightContext):base(flightContext)
        {            
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
           return await _flightContext.Flights.Include(p => p.PaxPrice).AsNoTracking()
                .AsQueryable().ToListAsync();
        }

        public async Task<IEnumerable<Flight>> GetFlightsByParams(FlightsRq flightSearch)
        {
            var flightsList = await _flightContext.Flights.Include(p => p.PaxPrice).AsNoTracking<Flight>().AsQueryable().ToListAsync();
            var filteredList = flightsList.Where(p => (DateTime.Equals(p.FlightDate, flightSearch.FlightDate) && p.Origin.Equals(flightSearch.Origin) && p.Destination.Equals(flightSearch.Destination))).ToList();
            return filteredList;
        }

        async Task<Flight> IFlightRepository.GetFlightByKey(BookingRq bookingRq)
        {
            var flightsList = _flightContext.Flights.Include(p => p.PaxPrice).AsNoTracking<Flight>().AsQueryable().ToListAsync().Result;
            await Task.CompletedTask;
            return flightsList.FirstOrDefault(c => c.FlightKey.Equals(bookingRq.FlightKey));
        }

    }
}
