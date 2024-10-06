using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Service
{
    
    public class EventService : IEventService
    {
       
        IEventRepository _eventRepository;  //interface object
        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public virtual void displayEventDetails(Event eventobj)
        {
            _eventRepository.displayEventDetails(eventobj);
        }
        public decimal calculateTotalRevenue(Event eventobj)
        {
          return (_eventRepository.calculateTotalRevenue(eventobj));
        }
        public int getBookedNoOfTickets(Event eventobj)
        {
            return (_eventRepository.getBookedNoOfTickets(eventobj));
        }

        public void bookTickets(int numTickets, Event eventobj)
        {
            _eventRepository.bookTickets(numTickets, eventobj);
        }
        public void cancelTickets(int numTickets, Event eventobj)
        {
            _eventRepository.cancelTickets(numTickets, eventobj);
        }

    }
}
