using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Entity
{
    public class Booking
    {
        private static int bookingCounter = 0;  
        public  int BookingId { get; set; }
        public Customer[] Customers {get ; set ;}
        public Event Event {  get; set; }
        public int numOfTickets { get; set; }
        public decimal totalCost { get; set; }  
        public DateTime BookingDate { get; set; }
    }
}
