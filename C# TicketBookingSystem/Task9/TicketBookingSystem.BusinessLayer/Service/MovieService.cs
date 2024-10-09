using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;
using TicketBookingSystem.BusinessLayer.Repository;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public class MovieService :  IMovieService
    {
        IMovieRepository _movieRepository;
        public MovieService(MovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }
        public  void displayEventDetails(Event eventobj)
        {
            _movieRepository.displayEventDetails(eventobj);
        }
    }
}
