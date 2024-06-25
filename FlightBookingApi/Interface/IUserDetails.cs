using FlightBookingApi.DTO;
using FlightBookingApi.Models;

namespace FlightBookingApi.Interface
{
    public interface IUserDetails
    {
        public string SignInUser(UserDetailsDTO user);
        public List<UserDetail> GetAllUsers();

    }
}
