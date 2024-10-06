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
    }
}
