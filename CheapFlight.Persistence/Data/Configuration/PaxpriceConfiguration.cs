using CheapFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheapFlight.Persistence.Data.Configuration
{
    public class PaxpriceConfiguration : IEntityTypeConfiguration<Paxprice>
    {
        public void Configure(EntityTypeBuilder<Paxprice> builder)
        {
            builder.ToTable("Paxprice");
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Type).IsRequired().HasMaxLength(3);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Flight).WithMany(p => p.PaxPrice).HasForeignKey(p => p.FlightId);
        }
    }
}
