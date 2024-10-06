using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class BookingRepository : IBookingRepository
    {
        int avaiableTickets;
        
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
    }
}
