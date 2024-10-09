using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.BusinessLayer.Service;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class BookingRepository : IBookingRepository
    {

        int avaiableTickets;
        private List<Booking> bookings = new List<Booking>();
        private static int bookingCounter = 0;

        public decimal calculateBookingCost(int numTickets,Event eventobj)
        {
            Console.WriteLine(" --- Calculating Booking Cost ---" );
            decimal bookCost;
            bookCost = numTickets * eventobj.ticketPrice;
            return bookCost;
        }
        public int getAvailableNoOfTickets(Event eventobj)
        {
            return eventobj.availableSeats;
        }

        

        public void AddBooking(Booking booking)
        {
            booking.BookingId = ++bookingCounter; 
            bookings.Add(booking);
            Console.WriteLine("Booking added successfully!");
        }

        public Booking GetBooking(int bookingId)
        {
            return bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }
        public void CreateBooking(Customer[] customers, Event eventObj, int numTickets)
        {
            if (customers.Length != numTickets)
            {
                throw new InvalidBookingException("The number of tickets must match the number of customers (Currently Customers=2)");
            }

            var booking = new Booking
            {
                Customers = customers,
                Event = eventObj,
                numOfTickets = numTickets,
                totalCost = numTickets * eventObj.ticketPrice,
                BookingDate = DateTime.Now
            };

            AddBooking(booking);
            GetBooking(1);
            DisplayBookingDetails(booking);

        }
        public void DisplayBookingDetails(Booking booking)
        {
            Console.WriteLine($"Booking ID: {booking.BookingId}");
            Console.WriteLine($"Booking Date: {booking.BookingDate}");
            Console.WriteLine($"Event: {booking.Event.eventName}");
            Console.WriteLine($"Total Cost: {booking.totalCost}");
            Console.WriteLine("Customer(s):");
            foreach (var customer in booking.Customers)
            {
                Console.WriteLine($"Customer Name: {customer.customerName}, Email: {customer.email}");
            }
        }

    }
}
