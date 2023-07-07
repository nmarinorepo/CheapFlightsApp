using CheapFlights.Domain.Entities;

namespace CheapFlights.Application.Utilities
{
    internal class BookingHelper
    {
        public static string GetBookingId(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetPaxTypeByBirthDate(DateTimeOffset birthDate)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            var now = DateTimeOffset.UtcNow;
            var timespan = now - birthDate;
            int years = (zeroTime + timespan).Year - 1;
            return years >= 16 ? "ADT" : "CHD";
        }

        public static decimal GetBookingTotalPrice(BookingRqEntity bookingRqEntity, Flight flight)
        {
            decimal result = 0;
            foreach (Paxprice pax in flight.PaxPrice)
            {
                var list = bookingRqEntity.Passengers.Where(p => p.PaxType.Equals(pax.Type)).Count();
                result = result + pax.Price * bookingRqEntity.Passengers.Where(p => p.PaxType.Equals(pax.Type)).Count();
            }
            return result;
        }
    }
}
