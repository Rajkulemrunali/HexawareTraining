using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class SportsRepository : EventRepository, ISportsRepository
    {
        public override void displayEventDetails(Event eventobj)
        {
            base.displayEventDetails(eventobj);
            if (eventobj is Sports sportsobj)
            {
                Console.WriteLine($"Sports Name : {sportsobj.sportsName}");
                Console.WriteLine($"Teams Name : {sportsobj.teamsName}");
            }
        }
    }
}
