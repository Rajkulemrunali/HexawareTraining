using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class ConcertRepository : EventRepository, IConcertRepository
    {
        public override void displayEventDetails(Event eventobj) // displayConcertRepository
        {
            base.displayEventDetails(eventobj);
            if (eventobj is Concert concertobj)
            {
                Console.WriteLine($"Concert Artist : {concertobj.artist}");
                Console.WriteLine($"Concert Type : {concertobj.type}");
            }
        }
    }
}
