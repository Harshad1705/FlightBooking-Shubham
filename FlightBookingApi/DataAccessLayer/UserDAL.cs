using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using FlightBookingApi.Models;
using System.Collections.Generic;

namespace FlightBookingApi.DataAccessLayer
{
    public class UserDAL : IUserDetails
    {
        public readonly FlightBookingContext _flightBookingContext;
        public UserDAL(FlightBookingContext flightBookingContext) 
        {
            _flightBookingContext = flightBookingContext;
        }

        public List<UserDetail> GetAllUsers()
        {
            List < UserDetailsDTO > users = new List < UserDetailsDTO >();
            var user = _flightBookingContext.UserDetails.Select(u=> new UserDetail
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNum = u.PhoneNum

            }).ToList();
            return user;
        }
        public string  SignInUser(UserDetailsDTO user)
        {
            UserDetail users = new UserDetail()
            {
                UserId = user.UserId,
                Password = user.Password,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNum = user.PhoneNum
                
            };

            _flightBookingContext.UserDetails.Add(users);
            var count = _flightBookingContext.SaveChanges();    
            if (count > 0)
            {
                return "User Created Successfully;";
            }
            return "";
        }

       
    }
}
