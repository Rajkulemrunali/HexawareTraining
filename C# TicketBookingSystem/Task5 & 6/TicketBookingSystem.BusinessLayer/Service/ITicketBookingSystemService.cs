using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public interface ITicketBookingSystemService
    {
        Event createEvent(string EventName, DateTime DateTime, int TotalSeats, int AvailableSeats, decimal TicketPrice, string EventType, string VenueName, params object[] specialAttributes);
        void displayEventDetails(Event eventobj);
        void bookTickets(int num, Event eventobj);

        void cancelTickets(int num, Event eventobj);
    }
}
