using FlightBookingApi.DTO;
using FlightBookingApi.Models;


namespace FlightBookingApi.Interface
{
    public interface IFlightBooking
    {
        public List<FlightDetailDTO> GetAllFlights();
        public string  AddFlight(FlightDetailDTO flightBooking);

        public List<FlightDetailDTO> SearchFlights(string source, string destination, DateTime date);
    }
}
