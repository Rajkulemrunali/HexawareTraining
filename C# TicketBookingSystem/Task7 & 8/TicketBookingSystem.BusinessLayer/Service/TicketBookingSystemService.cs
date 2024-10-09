using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public class TicketBookingSystemService : ITicketBookingSystemService
    {
        ITicketBookingSystemRepository _tbsRepository;
        public TicketBookingSystemService(TicketBookingSystemRepository tbsRepository) 
        {
            _tbsRepository = tbsRepository;
        }
        public Event createEvent(string EventName, DateTime DateTime, int TotalSeats, int AvailableSeats, decimal TicketPrice, string EventType, string VenueName, params object[] specialAttributes)
        {
            return _tbsRepository.createEvent( EventName,  DateTime, TotalSeats, AvailableSeats,   TicketPrice,  EventType,  VenueName, specialAttributes);
        }
        public void displayEventDetails(Event eventobj)
        {
            _tbsRepository.displayEventDetails( eventobj );
        }
        public void  bookTickets(int num, Event eventobj)
        {
            _tbsRepository.bookTickets( num, eventobj );
        }
        public void cancelTickets(int num, Event eventobj)
        {
            _tbsRepository.cancelTickets( num, eventobj );
        }



    }
}
