namespace FlightBookingApi.DTO
{
    public class BookTicketDTO
    {
        public long FlightId { get; set; }
        public decimal TotalAmount { get; set; }
        public long UserId { get; set; }
        public long TransactionNumber { get; set; }
        public int NumberOfPassenger { get; set; }
    }
}
