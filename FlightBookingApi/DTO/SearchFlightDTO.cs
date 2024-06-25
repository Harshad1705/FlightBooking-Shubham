namespace FlightBookingApi.DTO
{
    public class SearchFlightDTO
    {
        public string? Source { get; set; } = string.Empty;
        public string? Destination { get; set; } = string.Empty ;
        public DateOnly? FlightDate { get; set; }
    }
}
