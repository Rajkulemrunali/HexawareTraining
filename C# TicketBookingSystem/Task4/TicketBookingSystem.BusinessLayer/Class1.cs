using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer
{
    public class EventService
    {

        string eventName;
        DateTime eventDateTime;
        string venueName;
        int totalSeats;
        int availableSeats;
        decimal ticketPrice;
        enum eventType { Meovie, Sport, Concert }

        public EventService()
        {

        }
        public EventService(string eventName, DateTime eventDateTime, string venuename, int totalSeats, int availableSeats, decimal ticketPrice)
        {
            this.eventName = eventName;
            this.eventDateTime = eventDateTime;
            this.venueName = venueName;
            this.totalSeats = totalSeats;
            this.availableSeats = availableSeats;
            this.ticketPrice = ticketPrice;
        }

        public void calculateTotalRevenue()
        {

        }
        public void getBookedNoOfTickets()
        {

        }
        public void bookTickets(int numTickets)
        {

        }
        public void cancelTickets(int numTickets)
        {

        }
        public void displayEventDetails()
        {
            Console.WriteLine($"Event Name : {eventName}");
            Console.WriteLine($"Event Date And Time : {eventDateTime}");
            Console.WriteLine($"Venue Name : {venueName}");
            Console.WriteLine($"Total Seats : {totalSeats}");
            Console.WriteLine($"Available Seats : {availableSeats}");
            Console.WriteLine($"Ticket Price : {ticketPrice}");
            Console.Write("Event types : ");
            foreach (eventType eventType in Enum.GetValues(typeof(eventType)))
            {
                Console.WriteLine(eventType);
            }
        }
    }
    public class VenueService
    {
        public VenueService()
        {
        }
        public void displayVenueDetails()
        {

        }
    }
    public class CustomerService
    {
        public CustomerService()
        {
        }
        public void displayCustomerDetails()
        {

        }

    }
    public class BookingService
    {
        public BookingService()
        {
        }

        public void calculateBookingCost(int numTickets)
        {

        }
        public void bookTickets(int numtickets)
        {

        }
        public void cancelBooking(int numtickets)
        {

        }
        public void getAvailableNoOfTickets()
        {

        }
        public void getEventDetails()
        {

        }

    }
}