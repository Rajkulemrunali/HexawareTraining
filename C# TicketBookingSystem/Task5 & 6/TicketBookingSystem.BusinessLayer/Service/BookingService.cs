using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Service
{

    public class BookingService : IBookingService
    {
        IBookingRepository _bookingRepository = new BookingRepository();

        public BookingService(BookingRepository bookingRepository) 
        {
            _bookingRepository = bookingRepository;
        }

        public decimal calculateBookingCost(int numTickets, Event eventobj)
        {
            return _bookingRepository.calculateBookingCost(numTickets,eventobj);
        }
        public int getAvailableNoOfTickets(Event eventobj)
        {
            return _bookingRepository.getAvailableNoOfTickets(eventobj);
        }

    }
}
