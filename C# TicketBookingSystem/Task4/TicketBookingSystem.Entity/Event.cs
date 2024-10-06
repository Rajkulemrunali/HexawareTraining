using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Entity
{
    public class Event
    {
        public string  eventName {  get; set; }
        public DateTime eventDateTime { get; set; }
        public string venueName { get; set; }
        public int totalSeats { get; set; }
        public int availableSeats { get; set; }
        public decimal ticketPrice { get; set; }
        
    }
    
    
    
}
