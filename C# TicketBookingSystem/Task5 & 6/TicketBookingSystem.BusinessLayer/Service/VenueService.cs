using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.Entity;



namespace TicketBookingSystem.BusinessLayer.Service
{
    public class VenueService : IVenueService
    {
        IVenueRepository _venueRespository;
        public VenueService(VenueRepository venueRepository) 
        {
            _venueRespository = venueRepository;
        }
        public void displayVenueDetails(Venue venueobj)
        {
            _venueRespository.displayVenueDetails(venueobj);
        }
    }

}
