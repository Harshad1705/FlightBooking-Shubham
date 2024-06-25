using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using FlightBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public readonly IFlightBooking _flightBooking;

        public FlightController(IFlightBooking flightBooking)
        {
            _flightBooking = flightBooking;
        }
        

        // GET api/<FlightController>/5
        [HttpGet("GetAllFlights")]
        public List<FlightDetailDTO> GetAllFlights()
        {
            List <FlightDetailDTO> getFlight = new List<FlightDetailDTO> ();
            getFlight = _flightBooking.GetAllFlights();
            return getFlight;
        }

        // POST api/<FlightController>
        [HttpPost]
        public string  AddFlightPost([FromBody] FlightDetailDTO flight)
        {
             var message = _flightBooking.AddFlight(flight);
            return message;
        }
        [HttpGet("SearchFlights")]
        public List<FlightDetailDTO> SearchFlight(string source,string destination,DateTime date ) 
        {
            var searchList = _flightBooking.SearchFlights(source,destination,date);
            return searchList;
        }
      

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
