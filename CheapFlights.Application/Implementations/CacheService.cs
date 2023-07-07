using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;
using System.Diagnostics;

namespace CheapFlights.Application.Implementations
{
    public class CacheService : ICacheService
    {        

        private ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {            
            _cacheRepository = cacheRepository;
        }


        public void CreateBooking(BookingRqEntity bookingRs)
        {
            var key = $"{bookingRs.BookingId}";
            _cacheRepository.CreateBooking(key, bookingRs);
        }


        public BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq)
        {
            var key = $"{retrieveBookingRq.BookingId}";
            return _cacheRepository.RetrieveBooking(key);
        }
    }
}
