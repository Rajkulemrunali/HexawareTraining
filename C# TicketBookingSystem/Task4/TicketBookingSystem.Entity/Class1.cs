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
    public class Venue
    {
        public string venueName {  get; set; }
        public string venueAddress { get; set; }
    }
    
    public class Customer
    {
        public string customerName { get; set; }
        public string email { get; set; }

        public int phone_number { get; set; }
    }
}
