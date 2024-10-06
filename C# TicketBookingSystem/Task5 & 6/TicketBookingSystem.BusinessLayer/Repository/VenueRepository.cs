using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class VenueRepository : IVenueRepository
    {
        string venueName;
        string venueAddress;

        public void displayVenueDetails(Venue venueobj)
        {
            Console.WriteLine("-----   Displaying Venue Details   -----");
            Console.WriteLine($"Venue Name : {venueobj.venueName}");
            Console.WriteLine($"Venue Address : {venueobj.venueAddress}");

        }

    }
}
