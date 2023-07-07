using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Application.Utilities;
using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Implementations
{
    public class BookingService : IBookingService
    {
        private ICacheService _cacheService;
        private IFlightRepository _flightRepository;
        public BookingService(IFlightRepository flightRepository, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _flightRepository = flightRepository;
        }
               

        private Task<Flight> GetFlightByKey(BookingRq bookingRq)
        {
            return _flightRepository.GetFlightByKey(bookingRq);
        }

        public BookingRs CreateBooking(BookingRq bookingRq)
        {
            BookingRqEntity bookingRqEntity = new BookingRqEntity();
            bookingRqEntity.Contact = new ContactEntity() { FirstName = bookingRq.Contact.FirstName, LastName = bookingRq.Contact.LastName, Email = bookingRq.Contact.Email };
            bookingRqEntity.Passengers = new List<PassengerEntity>();
            foreach (Passenger passenger in bookingRq.Passengers)
            {
                string paxType = BookingHelper.GetPaxTypeByBirthDate(passenger.DateOfBirthPax);
                bookingRqEntity.Passengers.Add(new PassengerEntity() { DateOfBirthPax = passenger.DateOfBirthPax, FirstNamePax = passenger.FirstNamePax, LastNamePax = passenger.LastNamePax, PaxType = paxType });
            }

            Flight flight = GetFlightByKey(bookingRq).Result;

            bookingRqEntity.FlightKey = bookingRq.FlightKey;
            bookingRqEntity.BookingDate = DateTime.UtcNow;
            bookingRqEntity.FlightDate = flight.FlightDate;
            bookingRqEntity.Origin = flight.Origin;
            bookingRqEntity.Destination = flight.Destination;
            bookingRqEntity.FlightNumber = flight.FlightNumber;
            bookingRqEntity.BookingId = BookingHelper.GetBookingId(6);
            bookingRqEntity.TotalPrice = BookingHelper.GetBookingTotalPrice(bookingRqEntity, flight);

            if (CustomValidator.isValidBooking(bookingRqEntity))
            {
                _cacheService.CreateBooking(bookingRqEntity);

                BookingRs bookingRs = new BookingRs();
                bookingRs.FlightDate = bookingRqEntity.FlightDate;
                bookingRs.FlightNumber = flight.FlightNumber;
                bookingRs.BookingDate = bookingRqEntity.BookingDate;
                bookingRs.BookingId = bookingRqEntity.BookingId;
                bookingRs.Origin = bookingRqEntity.Origin;
                bookingRs.Destination = bookingRqEntity.Destination;
                bookingRs.Passengers = new List<PassengerRs>();
                foreach (PassengerEntity passenger in bookingRqEntity.Passengers)
                {
                    bookingRs.Passengers.Add(new PassengerRs() { DateOfBirthPax = passenger.DateOfBirthPax, FirstNamePax = passenger.FirstNamePax, LastNamePax = passenger.LastNamePax });
                }

                bookingRs.Contact = bookingRq.Contact;
                bookingRs.TotalPrice = (float)bookingRqEntity.TotalPrice;

                return bookingRs;
            }
            return null;
        }

        public BookingRs RetrieveBooking(RetrieveBookingRq retrieveBookingRq)
        {
            return _cacheService.RetrieveBooking(retrieveBookingRq);
        }
    }
}
