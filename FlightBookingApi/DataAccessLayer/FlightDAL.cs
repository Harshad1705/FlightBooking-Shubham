using FlightBookingApi.DTO;
using FlightBookingApi.Interface;
using FlightBookingApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingApi.DataAccessLayer
{
    public class FlightDAL : IFlightBooking
    {
        public readonly FlightBookingContext _flightBooking;
        public FlightDAL(FlightBookingContext flightBooking)
        {
            _flightBooking = flightBooking;
        }
        public List<FlightDetailDTO> GetAllFlights()
        {
            List<FlightDetailDTO> details =   _flightBooking.FlightDetails.Select(d => new FlightDetailDTO
            {
                AirLine = d.AirLine,
                Source = d.Source,
                Destination = d.Destination,
                DepartureTime = d.DepartureTime,
                ArrivalTime = d.ArrivalTime,
                AvailableSeats = d.AvailableSeats,
                TotalSeats = d.TotalSeats,
                Fare = d.Fare
            }).ToList();
            return details;
        }
        public string AddFlight(FlightDetailDTO addFlight)
        {
            FlightDetail flight = new FlightDetail()
            {
                AirLine = addFlight.AirLine,
                Source = addFlight.Source,
                Destination = addFlight.Destination,
                DepartureTime = addFlight.DepartureTime,
                ArrivalTime = addFlight.ArrivalTime,
                AvailableSeats = addFlight.AvailableSeats,
                TotalSeats = addFlight.TotalSeats,
                Fare = addFlight.Fare
            };

             _flightBooking.FlightDetails.Add(flight);
            var count = _flightBooking.SaveChanges();

            if(count > 0) 
            {
                return "Flight Added Successfully";
            }
            return "Something went wrong";
        }

        public List<FlightDetailDTO> SearchFlights(string source, string destination, DateTime date)
        {
            
           var flightList = _flightBooking.FlightDetails
                .Where(x => x.Source == source)
                .Where(x => x.Destination == destination)
                .Where(x => x.FlightDate == date).Select(x => new FlightDetail() { AirLine = x.AirLine,
           Source = x.Source,
           Destination = x.Destination,
           DepartureTime=x.DepartureTime,
           ArrivalTime=x.ArrivalTime,
           Fare=x.Fare})
                .ToList(); 

            List<FlightDetailDTO> seachList =  flightList.Select(x => new FlightDetailDTO
            {
                Source = x.Source,
                Destination = x.Destination,
                DepartureTime = x.DepartureTime,
                ArrivalTime = x.ArrivalTime,
                Fare=x.Fare
            }).ToList();    
            
            if(flightList.Count > 0)
            {
                return seachList;
            }
            return seachList;
        }
    }
}
