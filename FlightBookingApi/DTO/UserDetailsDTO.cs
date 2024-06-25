namespace FlightBookingApi.DTO
{
    public class UserDetailsDTO
    {
        public long UserId { get; set; } 
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public long? PhoneNum { get; set; } = 0;
        public bool? IsAdmin { get; set; } = false;
    }
}
