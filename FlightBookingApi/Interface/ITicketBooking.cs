using FlightBookingApi.DTO;

namespace FlightBookingApi.Interface
{
    public interface ITicketBooking
    {
        public string BookTicket(long userid, long flightId, BookTicketDTO bookTicket);
    }
}
