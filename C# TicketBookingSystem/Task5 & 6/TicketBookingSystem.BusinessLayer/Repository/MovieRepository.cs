using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class MovieRepository: EventRepository, IMovieRepository
    { 
      public override void displayEventDetails(Event eventobj)

        {
            base.displayEventDetails(eventobj);
            if (eventobj is Movie movieobj)
            {
                Console.WriteLine($"Event Genre : {movieobj.genre} ");
                Console.WriteLine($"Actor Name : {movieobj.actorName} ");
                Console.WriteLine($"Actress Name : {movieobj.actressName} ");
            }

        }
    }
}
