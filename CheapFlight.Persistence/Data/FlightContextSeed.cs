using System.Text.Json;
using CheapFlights.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CheapFlight.Persistence.Data
{
    public class FlightContextSeed
    {
        public static async Task SeedAsync(FlightContext context, ILoggerFactory loggerFactory)
        {
            try
            {                      
                if (!context.Flights.Any())
                {
                    var flightsData = File.ReadAllText("../CheapFlight.Persistence/Data/SeedData/flightsRs.json");
                    var flights = JsonSerializer.Deserialize<List<Flight>>(flightsData);
                    foreach (var item in flights)
                    {
                        context.Flights.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<FlightContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
