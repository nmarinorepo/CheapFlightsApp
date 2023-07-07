using API.Helpers.Errors;
using CheapFlights.Application.Interfaces;
using CheapFlights.Application.Models;
using CheapFlights.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class FlightsController : BaseApiController
    {
        private IFlightsService _flightsService;
        private readonly IBookingService _bookingService;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(IFlightsService flightsService, IBookingService bookingService, ILogger<FlightsController> logger)
        {
            _flightsService = flightsService;
            _bookingService = bookingService;
            _logger = logger;
        }


        // GET: api/<FlightsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Flight>>> Get()
        {
            _logger.LogInformation("Getting all flights...");

            var flights = await _flightsService.GetFlights();
            if(flights == null)
            {
                return NotFound(new ApiResponse(404, "There are no flights availables"));
            }
            return Ok(flights);
        }


        [HttpPost("SearchFlights")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights([FromBody]FlightsRq paramObj)
        {
            var flights = await _flightsService.GetFlightsByParams(paramObj);
            if (flights.Count().Equals(0))
            {
                return NotFound(new ApiResponse(404, "There are no flights availables with your parameters"));
            }
            return Ok(flights);

        }


        // POST: CreateBooking
        [HttpPost]
        [Route("CreateBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookingRs> CreateBooking([FromBody]BookingRq bookingRq)
        {
            var createdBooking = _bookingService.CreateBooking(bookingRq);
            if(createdBooking == null)
            {
                return BadRequest(new ApiResponse(400));
            }
            return Ok(createdBooking);
        }

        // POST: CreateBooking
        [HttpPost]
        [Route("RetrieveBooking")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingRs> RetrieveBooking([FromBody] RetrieveBookingRq retrieveBookingRq)
        {
            var retrievedBooking = _bookingService.RetrieveBooking(retrieveBookingRq);
            if(retrievedBooking == null)
            {
                return NotFound(new ApiResponse(404, "The requested booking does not exist."));
            }
            return Ok(retrievedBooking);
        }
    }
}
