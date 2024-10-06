using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Service
{
    public interface ICustomerService
    {
        void displayCustomerDetails(Customer customer);
    }
}
