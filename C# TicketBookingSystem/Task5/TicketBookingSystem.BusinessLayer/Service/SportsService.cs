using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public class SportsService : ISportsService
    {
        ISportsRepository _sportsRepository;
        public SportsService(SportsRepository sportsRepository) 
        {
            _sportsRepository = sportsRepository;
        }

        public void displayEventDetails(Event eventobj)
        {
            _sportsRepository.displayEventDetails(eventobj);
        }
    }
}
