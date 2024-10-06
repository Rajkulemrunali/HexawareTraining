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

            Event eventobj = new Event();
            Venue venueobj = new Venue();
            Customer customerobj = new Customer();

            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);

            eventobj.eventName = "Arijit's World Tour";
            eventobj.eventDateTime = DateTime.Now;
            eventobj.venueName = venueobj.venueName;
            eventobj.availableSeats = 500;
            eventobj.totalSeats = 600;
            eventobj.ticketPrice = 1000;

            VenueRepository venueRepository = new VenueRepository();
            VenueService venueService = new VenueService(venueRepository);

            venueobj.venueName = "Seasons Mall";
            venueobj.venueAddress = "Hadapsar,Pune,India";

            CustomerRepository customerRepository = new CustomerRepository();
            CustomerService customerService = new CustomerService(customerRepository);

            customerobj.customerName = "Mrunali Rajkule";
            customerobj.email = "mrunali@gmail.com";
            customerobj.phone_number = 1239874560;

            BookingRepository bookingRepository = new BookingRepository();
            BookingService bookingService = new BookingService(bookingRepository);


            //--------  Menu Driven  ----

            Console.WriteLine("");
            Console.WriteLine("----------       Task 4      ----------");
            Console.WriteLine("----------   OOPs Concepts   ----------");


            int choice = 0;  

            // Start the loop
            while (choice != 10)
            {
                Console.WriteLine("          --- Main Menu ---");
                Console.WriteLine("");
                Console.WriteLine("1. Display Event Details");
                Console.WriteLine("2. Display Venue Details");
                Console.WriteLine("3. Display Customer Details");
                Console.WriteLine("4. Calculate Total Revenue Of An Event ");
                Console.WriteLine("5. Get Booked Number Of Tickets ");
                Console.WriteLine("6. Book Tickets");
                Console.WriteLine("7. Cancel Tickets ");
                Console.WriteLine("8. Calculate Booking Cost");
                Console.WriteLine("9. Get Available Number Of Tickets");
                Console.WriteLine("10. EXIT");
                Console.WriteLine("");

                Console.Write("Enter Your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        eventService.displayEventDetails(eventobj);
                        break;
                    case 2:
                        venueService.displayVenueDetails(venueobj);
                        break;
                    case 3:
                        customerService.displayCustomerDetails(customerobj);
                        break;
                    case 4:
                        decimal totrevenue = eventService.calculateTotalRevenue(eventobj);
                        Console.WriteLine($"Total Revenue From Event : {eventobj.eventName} => {totrevenue}");
                        break;
                    case 5:
                        int bookTicketNo = eventService.getBookedNoOfTickets(eventobj);
                        Console.WriteLine($"Total Tickets Booked For Event : {eventobj.eventName} => {bookTicketNo}");
                        break;
                    case 6:
                        if (eventobj.availableSeats == 0)
                        {
                            Console.WriteLine("Event Sold Out!");
                            Console.WriteLine("Better Luck Next Time!");
                        }
                        else
                        {
                            Console.WriteLine("Enter Number Of Tickets To be Booked : ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            eventService.bookTickets(num, eventobj);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Number Of Tickets To Be Cancelled : ");
                        int numb = Convert.ToInt32(Console.ReadLine());
                        eventService.cancelTickets(numb, eventobj);
                        break;
                    case 8:
                        Console.WriteLine("Enter Number Of Tickets To Calculate Cost : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        decimal bookCost = bookingService.calculateBookingCost(n, eventobj);
                        Console.WriteLine($"Event : {eventobj.eventName}\nPrice Per Ticket : {eventobj.ticketPrice}\nTickets : {n} \n------------\nTotal Cost : {bookCost} ");
                        break;
                    case 9:
                        int avTicket = bookingService.getAvailableNoOfTickets(eventobj);
                        Console.WriteLine($"Available Tickets : {avTicket}");
                        break;
                    case 10:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice Entered");
                        break;
                }

                // Add a pause after displaying the result
                if (choice != 10)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();  // Pause for user input before showing the menu again
                }

                Console.Clear();  // Clears the console for a clean menu display
            }

            Console.WriteLine("Program has exited.");

            Console.ReadKey();
           

        }
    }
}
