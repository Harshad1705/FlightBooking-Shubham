using System;
using System.Collections.Generic;

namespace FlightBookingApi.Models
{
    public partial class FlightDetail
    {
        public FlightDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public long FlightId { get; set; }
        public string? AirLine { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public int? AvailableSeats { get; set; }
        public int? TotalSeats { get; set; }
        public decimal? Fare { get; set; }
        public DateTime? FlightDate { get; set; } 
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
