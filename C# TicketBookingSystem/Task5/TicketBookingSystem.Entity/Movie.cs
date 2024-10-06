using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Entity
{
    public class Movie : Event
    {
        public string genre {  get; set; }
        public string actorName { get; set; }
        public   string actressName { get; set; }   
    }
}
