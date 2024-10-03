using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task1Class
    {
        int availableTickets;
        int noOfBookingTicket;
        int remainingTickets;
        public int getAvailableTickets( )
        {
            Console.WriteLine("Enter Total No.Of Available Tickets :");
            availableTickets=Convert.ToInt16(Console.ReadLine());
            return availableTickets;
        }

        public int getNoOfBookingTicket()
        {
            Console.WriteLine("Enter Total No.Of Booking Tickets :");
            noOfBookingTicket = Convert.ToInt16(Console.ReadLine());
            return noOfBookingTicket;
        }

        public int checkTicketAvailability(int availableTickets, int noOfBookingTicket)
        {

            remainingTickets = availableTickets - noOfBookingTicket;
            if (remainingTickets > 0)
            {
                
                Console.WriteLine("Tickets Are Available!");
                
            }
            else
            {
                Console.WriteLine("Ticlets Sold Out!");
            }

            return remainingTickets;
        }

        

    }
}
