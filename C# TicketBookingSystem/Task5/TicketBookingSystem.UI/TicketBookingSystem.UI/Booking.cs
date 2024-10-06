using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;
using TicketBookingSystem.BusinessLayer.Service;

namespace TicketBookingSystem.UI
{
    class Booking
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------    Task 5    --------");
            Console.WriteLine("   Inheritance And Polymorphism     ");
            Console.WriteLine("");
            Console.WriteLine("    ---Main Menu---");

           

            TicketBookingSystemRepository tbsRepository = new TicketBookingSystemRepository();
            TicketBookingSystemService tbsService = new TicketBookingSystemService(tbsRepository);
            bool exitProgram = false;

            while (!exitProgram)
            {
                // Outer Menu
                Console.WriteLine("Select An Event:");
                Console.WriteLine("1. Movie Event ");
                Console.WriteLine("2. Sports Event ");
                Console.WriteLine("3. Concert Event");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Your Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Event obj = null;

                switch (ch)
                {
                    case 1:
                        obj = tbsService.createEvent("Jab We Met", DateTime.Parse("2024-10-18 04:30"), 320, 180, 180, "Movie", "PVR, Pune", "Rom-Com","Shahid Kapoor", "Kareena Kapoor" );
                        break;
                    case 2:
                        obj = tbsService.createEvent("IPL 2025", DateTime.Parse("2024-10-18 04:30"), 1000, 200, 500, "Sports", "Wankhede Stadium, Mumbai", "Cricket", "MI vs CSK");
                        break;
                    case 3:
                        obj = tbsService.createEvent("Sunburn Arena", DateTime.Parse("2024-10-18 04:30"), 1000, 200, 500, "Concert", "MayField Eva Garden, Pune", "Alan Walker", "Rock");
                        break;
                    case 4:
                        exitProgram = true;
                        Console.WriteLine("Exiting the Program...");
                        continue; 
                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        continue;
                }

                // Inner Menu for Event Actions
                bool exitInnerLoop = false;

                while (!exitInnerLoop)
                {
                    Console.WriteLine("\nMenu For Selected Event");
                    Console.WriteLine("1. Display EventDetails");
                    Console.WriteLine("2. Book Tickets");
                    Console.WriteLine("3. Cancel Tickets");
                    Console.WriteLine("4. Back to Main Menu");
                    Console.Write("Select an action: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            tbsService.displayEventDetails(obj);
                            break;
                        case 2:
                            Console.Write("Enter Number Of Tickets To Book: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            tbsService.bookTickets(n, obj);
                            break;
                        case 3:
                            Console.Write("Enter Number Of Tickets To Cancel: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            tbsService.cancelTickets(num, obj);
                            break;
                        case 4:
                            exitInnerLoop = true; 
                            break;
                        default:
                            Console.WriteLine("Invalid Action. Try Again.");
                            break;
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
