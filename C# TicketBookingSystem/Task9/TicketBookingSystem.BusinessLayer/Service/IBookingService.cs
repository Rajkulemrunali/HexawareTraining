using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public interface IBookingService
    {
        decimal calculateBookingCost(int numTickets,Event eventobj);
         int getAvailableNoOfTickets(Event eventobj);
        void AddBooking(Booking booking);
        Booking GetBooking(int bookingId);
        void CreateBooking(Customer[] customers, Event eventObj, int numTickets);
        void DisplayBookingDetails(Booking booking);
    }
}
