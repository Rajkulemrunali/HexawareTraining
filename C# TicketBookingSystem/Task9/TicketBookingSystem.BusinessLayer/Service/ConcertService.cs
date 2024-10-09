using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public class ConcertService : IConcertService
    {
        IConcertRepository _concertRepository;
        public ConcertService(ConcertRepository concertRepository) 
        {
            _concertRepository = concertRepository;
        }
        public void displayEventDetails(Event eventobj)    // displayConcertRepository
        {
            _concertRepository.displayEventDetails(eventobj);
        }
    }
}
