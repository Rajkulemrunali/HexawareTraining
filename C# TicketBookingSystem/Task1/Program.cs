using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- TASK 1 : CONTROL STRUCTURE ----------");
            Console.WriteLine("----------   CONDITIONAL STATEMENTS   ----------");
            Console.WriteLine(" ");

            Task1Class task1ClassObj= new Task1Class();
            int availTicket = task1ClassObj.getAvailableTickets();
            int bookTicket  = task1ClassObj.getNoOfBookingTicket();
            int remTicket   = task1ClassObj.checkTicketAvailability(availTicket, bookTicket);

            Console.WriteLine("Tickets Remaining : " + remTicket);

            Console.ReadKey();


        }
    }
}
