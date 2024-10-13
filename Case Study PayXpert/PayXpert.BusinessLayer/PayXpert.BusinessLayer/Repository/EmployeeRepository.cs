using PayXpert.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;

namespace PayXpert.BusinessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeData employeeData = new EmployeeData();
        public void GetEmployeeById(int id)
        {
            employeeData.GetEmployeeById(id);
        }

        public void GetAllEmployees()
        {
            employeeData.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("---Adding Details----");
            //Console.Write("Enter EmployeeId : ");
            //employee.EmployeeID=Convert.ToInt32(Console.ReadLine());
            employee.EmployeeID = 0;
            Console.Write("Enter FirstName : ");
            employee.Firstname = (Console.ReadLine());
            if (string.IsNullOrWhiteSpace(employee.Firstname))
            {
                throw new InvalidInputException("First Name cannot be empty.");
            }
            Console.Write("Enter LastName : ");
            employee.Lastname = (Console.ReadLine());
            if (string.IsNullOrWhiteSpace(employee.Lastname))
            {
                throw new InvalidInputException("Last Name cannot be empty.");
            }
            Console.Write("Enter DOB : ");
            employee.DOB= Convert.ToDateTime(Console.ReadLine());
            if (employee.DOB > DateTime.Now)
            {
                throw new InvalidInputException("Date of Birth cannot be in the future.");
            }
            Console.Write("Enter Gender : ");
            employee.Gender = Console.ReadLine();
            employee.Gender = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(employee.Gender))
            {
                throw new InvalidInputException("Gender cannot be empty.");
            }
            Console.Write("Enter Email : ");
            employee.Email = Console.ReadLine();
            if (!IsValidEmail(employee.Email))
            {
                throw new InvalidInputException("Invalid email format.");
            }
            Console.Write("Enter Phone Number : ");
            employee.PhoneNumber = Console.ReadLine();
            if (!IsValidPhoneNumber(employee.PhoneNumber))
            {
                throw new InvalidInputException("Invalid phone number.");
            }
            Console.Write("Enter Address : ");
            employee.Address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(employee.Address))
            {
                throw new InvalidInputException("Address cannot be empty.");
            }
            Console.Write("Enter Position : ");
            employee.Position = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(employee.Position))
            {
                throw new InvalidInputException("Position cannot be empty.");
            }
            Console.Write("Enter Joining Date : ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime joiningDate))
            {
                throw new InvalidInputException("Invalid Joining Date.");
            }
            employee.JoiningDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Termination : ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime terminationDate))
            {
                throw new InvalidInputException("Invalid Termination Date.");
            }
            employee.Termination = Convert.ToDateTime(Console.ReadLine());

            employeeData.AddEmployee(employee);
            

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10; // Adjust validation rules as needed.
        }
        public void UpdateEmployee(Employee employee)
        {
            Console.WriteLine("---Updating Details----");
            Console.Write("Enter EmployeeId : ");
            employee.EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter FirstName : ");
            employee.Firstname = (Console.ReadLine());
            Console.Write("Enter LastName : ");
            employee.Lastname = (Console.ReadLine());
            Console.Write("Enter DOB : ");
            employee.DOB = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Gender : ");
            employee.Gender = Console.ReadLine();
            Console.Write("Enter Email : ");
            employee.Email = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Address : ");
            employee.Address = Console.ReadLine();
            Console.Write("Enter Position : ");
            employee.Position = Console.ReadLine();
            Console.Write("Enter Joining Date : ");
            employee.JoiningDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Termination : ");
            employee.Termination = Convert.ToDateTime(Console.ReadLine());

            employeeData.UpdateEmployee(employee);
        }

        public void RemoveEmployee(int employeeId)
        {
            employeeData.RemoveEmployee(employeeId);
        }
    }
}
