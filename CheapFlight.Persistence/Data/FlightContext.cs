using CheapFlights.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CheapFlight.Persistence.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options): base(options)
        {            
        }
               
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Paxprice> Paxprices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>().HasMany(c => c.PaxPrice).WithOne(e => e.Flight).HasForeignKey(e=>e.FlightId);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());         
        }
    }
}
