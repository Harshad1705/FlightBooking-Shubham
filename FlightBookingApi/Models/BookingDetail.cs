﻿using System;
using System.Collections.Generic;

namespace FlightBookingApi.Models
{
    public partial class BookingDetail
    {
        public long BookingId { get; set; }
        public long FlightId { get; set; }
        public decimal TotalAmount { get; set; }
        public long UserId { get; set; }
        public long TransactionNumber { get; set; }
        public int NumberOfPassenger { get; set; }
        public long PassengerId { get; set; }

        public virtual FlightDetail Flight { get; set; } = null!;
        public virtual PassengerDetail Passenger { get; set; } = null!;
        public virtual UserDetail User { get; set; } = null!;
    }
}
