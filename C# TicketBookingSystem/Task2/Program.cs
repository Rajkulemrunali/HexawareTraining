using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("----------  Task 2 : Nested Conditional Statements  -----------");
            Console.WriteLine("");

            Console.WriteLine("Ticket Booking System");
            Console.WriteLine("");

            Task2Classs task2ClasssObj = new Task2Classs();

            string tt;     //ticket type
            int nt;        //no,of ticket
            int tc = 0;    //total cost
            
          
            task2ClasssObj.ticketBaseRate(450, 750, 1000);

            Console.WriteLine("Ticket Options Available Now: ");
            task2ClasssObj.displayTicketOption();
            
            Console.WriteLine("");

            Console.WriteLine("BOOK TICKET NOW -(Y/N/EXIT)");

            string ch = Console.ReadLine();
            switch (ch)
            {
                case "Y":
                case "y":
                    {
                        Console.WriteLine("Enter Ticket Type: ");
                        tt = Console.ReadLine();
                        Console.WriteLine("Enter No.Of Tickets: ");
                        nt = Convert.ToInt32(Console.ReadLine());

                        switch (tt)
                        {
                            case "silver":
                            case "Silver":
                            case "SILVER":
                                tc = task2ClasssObj.totalTicketCost("s", nt);
                                break;
                            case "gold":
                            case "Gold":
                            case "GOLD":
                                tc = task2ClasssObj.totalTicketCost("g", nt);
                                break;
                            case "diamond":
                            case "Diamond":
                            case "DIAMOND":
                                tc = task2ClasssObj.totalTicketCost("d", nt);
                                break;
                            default:
                                Console.WriteLine("**INVALID TICKET TYPE**");
                                break;

                        }
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine($"Your Total Cost For {nt} Tickets Is {tc} ");

                        Console.ReadKey();
                        break;
                    }
                case "N":
                case "n":
                    {
                        break;
                    }

            }
        }
    }
}
