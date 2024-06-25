using System;
using System.Collections.Generic;

namespace FlightBookingApi.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public long UserId { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public long? PhoneNum { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
