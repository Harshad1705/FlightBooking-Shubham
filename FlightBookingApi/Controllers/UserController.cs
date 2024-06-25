using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using FlightBookingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserDetails _userDetails;
        public UserController(IUserDetails userDetails)
        {
            _userDetails = userDetails;
        }
       
        [HttpGet]
        public IActionResult SignInUser() 
        {

            return Ok();
        }
        [HttpPost("SignIn")]  
        public IActionResult SignInUser(UserDetailsDTO user) 
        {
            var message = _userDetails.SignInUser(user);

            return Ok(message);
        }
    }
}

//***************************** you tube Link************
//https://www.youtube.com/watch?v=QDCAIYs1Ktk