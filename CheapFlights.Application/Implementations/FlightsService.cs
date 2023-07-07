using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Implementations
{
    public class FlightsService : IFlightsService
    {
        private IFlightRepository _flightRepository;

        public FlightsService(IFlightRepository flightRepository, ICacheService cacheService, IBookingService bookingService)
        {
            _flightRepository = flightRepository;
        }

        public Task<IEnumerable<Flight>> GetFlights()
        {
            return _flightRepository.GetFlights();
        }

        public async Task<IEnumerable<Flight>> GetFlightsByParams(FlightsRq flightsRq)
        {
            var flightsList = await _flightRepository.GetFlightsByParams(flightsRq);
            
            foreach (Flight flight in flightsList)
            {
                foreach (Paxprice pax in flight.PaxPrice)
                {
                    pax.Price = pax.Price * flightsRq.PaxType.FirstOrDefault(p => p.Type.Equals(pax.Type)).Quantity;
                }
            }
            return flightsList;
        }

    }
}
