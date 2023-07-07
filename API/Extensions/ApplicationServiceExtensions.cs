
using API.Helpers.Errors;
using CheapFlight.Persistence.Cache;
using CheapFlight.Persistence.Repositories;
using CheapFlights.Application.Implementations;
using CheapFlights.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IFlightsService, FlightsService>();
            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<ICacheRepository, CacheRepository>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IBookingService, BookingService>();
        }

        public static void AddValidationErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                    .SelectMany(u => u.Value.Errors)
                                                    .Select(u => u.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidation()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }
    }
}
