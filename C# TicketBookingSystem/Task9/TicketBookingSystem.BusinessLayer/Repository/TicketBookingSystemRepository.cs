using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class TicketBookingSystemRepository : EventRepository,ITicketBookingSystemRepository
    {
        public Event createEvent(string EventName,DateTime DateTime, int TotalSeats,int AvailableSeats, decimal TicketPrice, string EventType, string VenueName, params object[] specialAttributes)
        {
            Event eventObj;

            switch (EventType.ToLower())
            {
                case "movie":
                    Movie movieObj = new Movie();
                    movieObj.eventName = EventName;
                    movieObj.eventDateTime = DateTime;
                    movieObj.totalSeats = TotalSeats;
                    movieObj.availableSeats = AvailableSeats;
                    movieObj.ticketPrice = TicketPrice;
                    movieObj.venueName = VenueName;
                    movieObj.genre = (string)specialAttributes[0];
                    movieObj.actorName = (string)specialAttributes[1];
                    movieObj.actressName = (string)specialAttributes[2];

                    eventObj = movieObj;
                    break;

                case "sports":
                    Sports sportsObj = new Sports();
                    sportsObj.eventName = EventName;
                    sportsObj.eventDateTime = DateTime;
                    sportsObj.totalSeats = TotalSeats;
                    sportsObj.availableSeats = AvailableSeats;
                    sportsObj.ticketPrice = TicketPrice;
                    sportsObj.venueName = VenueName;
                    sportsObj.sportsName = (string)specialAttributes[0]; 
                    sportsObj.teamsName = (string)specialAttributes[1]; 
                    eventObj = sportsObj;
                    break;

                case "concert":
                    Concert concertObj = new Concert();
                    concertObj.eventName = EventName;
                    concertObj.eventDateTime = DateTime;
                    concertObj.totalSeats = TotalSeats;
                    concertObj.availableSeats =AvailableSeats;
                    concertObj.ticketPrice = TicketPrice;
                    concertObj.venueName = VenueName;
                    concertObj.artist = (string)specialAttributes[0]; 
                    concertObj.type = (string)specialAttributes[1]; 
                    eventObj = concertObj;
                    break;

                default:
                    throw new ArgumentException("Invalid event type specified");
            }

            return eventObj; 
        }
        public override void displayEventDetails(Event eventobj)
        {
            if (eventobj is Movie movie)  // Check if the event is a Movie
            {
                MovieRepository mRepository = new MovieRepository();
                mRepository.displayEventDetails(movie);  // Calls the Movie-specific version
            }
            else if (eventobj is Sports sports)  // Check if the event is a Sports event
            {
                SportsRepository sRepository = new SportsRepository();
                sRepository.displayEventDetails(sports);  // Calls the Sports-specific version
            }
            else if (eventobj is Concert concert)  // Check if the event is a Concert
            {
                ConcertRepository cRepository = new ConcertRepository();
                cRepository.displayEventDetails(concert);  // Calls the Concert-specific version
            }
            else
            {
                // Default fallback: display the base Event details
                Console.WriteLine("-----   Displaying Event Details   ------");
                Console.WriteLine($"Event Name : {eventobj.eventName}");
                Console.WriteLine($"Event Date And Time : {eventobj.eventDateTime}");
                Console.WriteLine($"Venue Name : {eventobj.venueName}");
                Console.WriteLine($"Total Seats : {eventobj.totalSeats}");
                Console.WriteLine($"Available Seats : {eventobj.availableSeats}");
                Console.WriteLine($"Ticket Price : {eventobj.ticketPrice}");
            }

        }

        public override void bookTickets(int num, Event eventobj)
        {
            base.bookTickets(num, eventobj);
        }
        public override void cancelTickets(int num, Event eventobj)
        {
            base.cancelTickets(num, eventobj);
        }


    }
}
