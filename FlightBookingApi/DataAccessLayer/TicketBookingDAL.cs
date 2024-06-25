using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using FlightBookingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.DataAccessLayer
{
    public class TicketBookingDAL : ITicketBooking
    {
        public readonly FlightBookingContext _TickettBookingContext;
        public readonly UserDAL _userDAL;
        public readonly FlightDAL _flightDAL;


        public TicketBookingDAL(FlightBookingContext TickettBookingContext, UserDAL userDAL, FlightDAL flightDAL)
        {
            _TickettBookingContext = TickettBookingContext;
            _userDAL = userDAL;
            _flightDAL = flightDAL;
        }

        public string BookTicket(long userid, long flightId, BookTicketDTO bookTicket)
        {
            var user = _userDAL.GetAllUsers().Where(u => u.UserId == userid).FirstOrDefault();
            var flight = _TickettBookingContext.FlightDetails.Where(u=>u.FlightId == flightId).FirstOrDefault();
            var passanger = _TickettBookingContext.PassengerDetails.Where(p=>p.PassengerId == 0).FirstOrDefault();
            if (user != null && flight != null) 
            {
                var userID = new BookingDetail()
                {
                    User = user,
                    Flight = flight,
                    Passenger = passanger,
                    FlightId = bookTicket.FlightId,
                    TotalAmount = bookTicket.TotalAmount,
                    UserId = user.UserId,
                    TransactionNumber = bookTicket.TransactionNumber,
                    NumberOfPassenger = bookTicket.NumberOfPassenger
                };
                _TickettBookingContext.BookingDetails.Add(userID);
                var count  = _TickettBookingContext.SaveChanges();
                if (count > 0)
                {
                    return "Ticket booked successfully.";
                }
            }
            
            return "Something went wrong";
        }
    }
}
