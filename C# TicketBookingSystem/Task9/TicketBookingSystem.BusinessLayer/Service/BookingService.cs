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
        public void AddBooking(Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }
        public Booking GetBooking(int bookingId)
        {
            return _bookingRepository.GetBooking(bookingId);
        }
        public void CreateBooking(Customer[] customers, Event eventObj, int numTickets)
        {
            _bookingRepository.CreateBooking(customers, eventObj, numTickets);
            //_bookingRepository.AddBooking(booking);

        }

        public void DisplayBookingDetails(Booking booking)
        {
            _bookingRepository.DisplayBookingDetails(booking);
        }

    }
}
