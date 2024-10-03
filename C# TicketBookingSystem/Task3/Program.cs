using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task3
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("----------  Task 3 : Nested Conditional Statements  -----------");
            Console.WriteLine("----------              Loop Until Exit             -----------");

            Console.WriteLine("");

            Console.WriteLine("Ticket Booking System");
            Console.WriteLine("");
            Task3Classs task3ClasssObj = new Task3Classs();

            string tt;     //ticket type
            int nt;        //no,of ticket
            int tc = 0;    //total cost
            string ch;

            task3ClasssObj.ticketBaseRate(450, 750, 1000);
            Console.WriteLine("Ticket Options Available Now: ");
            task3ClasssObj.displayTicketOption();

            Console.WriteLine("");

            do
            {
                Console.WriteLine("BOOK TICKET NOW -(Y/N/EXIT)");
                ch = Console.ReadLine();

                if (ch.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

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
                                    tc = task3ClasssObj.totalTicketCost("s", nt);
                                    break;
                                case "gold":
                                case "Gold":
                                case "GOLD":
                                    tc = task3ClasssObj.totalTicketCost("g", nt);
                                    break;
                                case "diamond":
                                case "Diamond":
                                case "DIAMOND":
                                    tc = task3ClasssObj.totalTicketCost("d", nt);
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
                            Console.WriteLine("You Choose Not To Book Tickets !! ");
                            break;
                        }

                }
              //  Console.WriteLine("BOOK TICKET NOW -(Y/N/EXIT)");

            } while  (true);
            Console.ReadKey();

        }
    }
}
