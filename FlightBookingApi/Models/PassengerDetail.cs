using System;
using System.Collections.Generic;

namespace FlightBookingApi.Models
{
    public partial class PassengerDetail
    {
        public PassengerDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public long PassengerId { get; set; }
        public string Name { get; set; } = null!;
        public short Age { get; set; }
        public long BookingId { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
