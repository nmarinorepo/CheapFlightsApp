using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CheapFlight.Persistence.Cache
{        
    public class CacheRepository : ICacheRepository
    {
        private IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void CreateBooking(string key, BookingRqEntity bookingRqEntity)
        {
            BookingRqEntity booking;
            if (!_cache.TryGetValue<BookingRqEntity>(key, out booking))
            {
                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3600))
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));

                _cache.Set(key, bookingRqEntity, options);
            }
        }

        public BookingRs RetrieveBooking(string key)
        {
            BookingRqEntity booking;
            if (_cache.TryGetValue<BookingRqEntity>(key, out booking))
            {
                BookingRs bookingRs = new BookingRs();
                bookingRs.BookingDate = booking.BookingDate;
                bookingRs.BookingId = booking.BookingId;
                bookingRs.Contact = new Contact() { FirstName = booking.Contact.FirstName, LastName = booking.Contact.LastName, Email = booking.Contact.Email };
                bookingRs.Origin = booking.Origin;
                bookingRs.Destination = booking.Destination;
                bookingRs.FlightDate = booking.FlightDate;
                bookingRs.FlightNumber = booking.FlightNumber;
                bookingRs.Passengers = new List<PassengerRs>();
                foreach (PassengerEntity passenger in booking.Passengers)
                {
                    bookingRs.Passengers.Add(new PassengerRs() { DateOfBirthPax = passenger.DateOfBirthPax, FirstNamePax = passenger.FirstNamePax, LastNamePax = passenger.LastNamePax });
                }

                bookingRs.TotalPrice = (float)booking.TotalPrice;
                return bookingRs;
            }
            return null;
        }
    }
}
