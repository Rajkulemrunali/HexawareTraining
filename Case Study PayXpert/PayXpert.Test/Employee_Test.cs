using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PayXpert.BusinessLayer.Repository;
using PayXpert.BusinessLayer.Service;
using PayXpert.DataAccessLayer;
using PayXpert.Entity;
using System.IO;

namespace PayXpert.Test
{
    [TestFixture]
    public class Employee_Test
    {
        [Test]
        public void AddEmployee_Test()
        {
            EmployeeData employeeData = new EmployeeData();
            Employee employee = new Employee()
            {
                EmployeeID = 19,
                Firstname = "Monika",
                Lastname = "roy",
                DOB = new DateTime(1990, 5, 10),
                Gender = "Female",
                Email = "monika@example.com",
                PhoneNumber = "658658658",
                Address = "Gujarat",
                Position = "Engineer",
                JoiningDate = new DateTime(2019, 5, 10),
                Termination = new DateTime(2020, 5, 10)
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                employeeData.AddEmployee(employee);
                var actual_result = sw.ToString().Trim();
                var expected_result = $"Employee with {employee.EmployeeID} Added Successfully";

                //Console.WriteLine("Actual Result: " + actual_result);
                // Console.WriteLine("Expected Result: " + expected_result);
                Assert.That(expected_result, Is.EqualTo(actual_result));
            }
        }

        [Test]
        public void RemoveEmployee_Test()
        {
            EmployeeData employeeData = new EmployeeData();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                employeeData.RemoveEmployee(10);
                var actual_result = sw.ToString().Trim();
                var expected_result = "Employee Removed Sucessfully : ";

                //Console.WriteLine("Actual Result: " + actual_result);
                //Console.WriteLine("Expected Result: " + expected_result);
                Assert.That(expected_result, Is.EqualTo(actual_result));
            }
        }
    }
}
