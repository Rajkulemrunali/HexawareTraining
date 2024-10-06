using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class EventRepository : IEventRepository
    {
        string eventName;
        DateTime eventDateTime;
        string venueName;
        int totalSeats;
        int availableSeats;
        decimal ticketPrice;
        enum eventType { Meovie, Sport, Concert }
        public decimal calculateTotalRevenue(Event eventobj)
        {
            int noOfTicketSold;
            decimal totalRevenue;

            noOfTicketSold = eventobj.totalSeats - eventobj.availableSeats;
            totalRevenue = noOfTicketSold * eventobj.ticketPrice;

            Console.WriteLine($"Ticket Price : {eventobj.ticketPrice}");
            Console.WriteLine($"Total Tickets Sold : {noOfTicketSold}");

            return totalRevenue;
        }
        
        public int getBookedNoOfTickets(Event eventobj)
        {
            int noOfBookedTickets;
            noOfBookedTickets = eventobj.totalSeats - eventobj.availableSeats;

            return noOfBookedTickets;
        }
        
        public void bookTickets(int numTickets, Event eventobj)
        {
            Console.WriteLine($"     Initiating Booking ..... ");
            
            if (numTickets > eventobj.availableSeats)
            {
                Console.WriteLine($"Sorry Only {eventobj.availableSeats} Seats Available !!");
                Console.Write($"Continue Booking {eventobj.availableSeats} Seats ? (Y/N)");
                string ch = Console.ReadLine();
                if (ch.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    bookTickets(eventobj.availableSeats, eventobj);
                }
                else
                {
                    Console.WriteLine("***** Booking Failed *****");
                }

            }
            else
            {
                eventobj.availableSeats = eventobj.availableSeats - numTickets;
                Console.WriteLine($" -- Booking Reciept --");
                Console.WriteLine($"Event : {eventobj.eventName}\nPrice Per Ticket: {eventobj.ticketPrice}\nTickets  :  {numTickets} \n ------- \nTotal Amount : {numTickets * eventobj.ticketPrice}");
                Console.WriteLine("*****Booking Successfull*****");
                Console.WriteLine("");
            }

        }
        
        public void cancelTickets(int numTickets, Event eventobj)
        {
            Console.WriteLine($"     Initiating Cancelling ..... ");
            eventobj.availableSeats = eventobj.availableSeats + numTickets;
            Console.WriteLine($" -- Refund Reciept --");
            Console.WriteLine($"Event : {eventobj.eventName}\nPrice Per Ticket : {eventobj.ticketPrice}\nTickets  :   {numTickets} \n ------- \nRefundable Amount : {numTickets * eventobj.ticketPrice}");
            Console.WriteLine("*****Cancelling Successfull*****");
            Console.WriteLine("");

        }

        public void displayEventDetails(Event eventobj)
        {
            Console.WriteLine("-----   Displaying Event Details   ------");
            Console.WriteLine($"Event Name : {eventobj.eventName}");
            Console.WriteLine($"Event Date And Time : {eventobj.eventDateTime}");
            Console.WriteLine($"Venue Name : {eventobj.venueName}");
            Console.WriteLine($"Total Seats : {eventobj.totalSeats}");
            Console.WriteLine($"Available Seats : {eventobj.availableSeats}");
            Console.WriteLine($"Ticket Price : {eventobj.ticketPrice}");
            Console.Write("Event types : ");
            foreach (eventType eventType in Enum.GetValues(typeof(eventType)))
            {
                Console.WriteLine(eventType);
            }
        }
    }
}
