using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Entity
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Firstname {  get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? Termination {  get; set; }
    }
}
