using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CheapFlights.Domain.Entities;

namespace CheapFlight.Persistence.Data.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flights");           
            builder.Property(p => p.FlightDate).HasColumnType("datetimeoffset(7)");
        }
    }
}
