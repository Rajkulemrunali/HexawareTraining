using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Entity;

namespace TicketBookingSystem.BusinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        string customerName;
        string email;
        int phone_number;

        public void displayCustomerDetails(Customer customer)
        {
            Console.WriteLine("-----   Displaying Customer Details   -----");
            Console.WriteLine($"Customer Name : {customer.customerName}");
            Console.WriteLine($"Customer Email : {customer.email}");
            Console.WriteLine($"Customer Phone Number : {customer.phone_number}");
        }

    }
}
