using FlightBookingApi.Models;

namespace FlightBookingApi.DTO
{
    public class FlightDetailDTO
    {
        public long FlightId { get; set; }
        public string? AirLine { get; set; } = string.Empty;
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public int? AvailableSeats { get; set; }
        public int? TotalSeats { get; set; }
        public decimal? Fare { get; set; }
    }
}
