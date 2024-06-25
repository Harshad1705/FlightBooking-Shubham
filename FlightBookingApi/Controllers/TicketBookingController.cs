using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketBookingController : ControllerBase
    {
        public readonly ITicketBooking _ticketBooking;
        public TicketBookingController(ITicketBooking ticketBooking)
        {
                _ticketBooking = ticketBooking;
        }

        [HttpPost("BookTicket")]
        public string BookTicket([FromQuery] long userid, [FromQuery] long flightId, [FromBody] BookTicketDTO bookTicket)
        {
            var msg = _ticketBooking.BookTicket( userid,  flightId,   bookTicket);
            return "";
        }
    }
}
