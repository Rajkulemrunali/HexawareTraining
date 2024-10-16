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
using Moq;

namespace PayXpert.Test
{
    [TestFixture]
    public class Employee_Test
    {
        [Test]
        public void GetEmployeeById_ReturnEmployee()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>(); // Mocking the repository
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);
            int employeeId = 1;

            // Creating a sample employee object to return when GetEmployeeById is called
            var mockEmployee = new Employee
            {
                EmployeeID = employeeId,
                Firstname = "Harry",
                Lastname = "Potter",
                DOB = new DateTime(1990, 1, 1),
                Gender = "Male",
                Email = "harry@example.com",
                PhoneNumber = "1234567890",
                Address = "New York City",
                Position = "Engineer",
                JoiningDate = new DateTime(2015, 6, 1)
            };

            // Setting up the mock repository to return the mock employee when GetEmployeeById is called
            employeeRepositoryMock.Setup(repo => repo.GetEmployeeById(employeeId)).Returns(mockEmployee);

            // Act
            var result = employeeService.GetEmployeeById(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.EmployeeID);
            Assert.AreEqual("Harry", result.Firstname);
            Assert.AreEqual("Potter", result.Lastname);


            // Verify that the method was called exactly once
            employeeRepositoryMock.Verify(repo => repo.GetEmployeeById(employeeId), Times.Once);
        }

        [Test]
        public void GetAllEmployees_ReturnsListOfEmployees()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    Firstname = "Diya",
                    Lastname = "Mirza",
                    Email = "diya@example.com",
                },
                    new Employee
                    {
                        EmployeeID = 2,
                        Firstname = "Mira",
                        Lastname = "Jones",
                        Email = "mira@example.com",
                    }
                };

            employeeRepositoryMock.Setup(repo => repo.GetAllEmployees()).Returns(employees);
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var result = employeeService.GetAllEmployees();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Diya", result[0].Firstname);
            Assert.AreEqual("Mira", result[1].Firstname);
        }

        [Test]
        public void AddEmployee_ReturnsTrue_WhenEmployeeIsAddedSuccessfully()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var newEmployee = new Employee
            {
                Firstname = "Captain",
                Lastname = "America",
                Email = "captainn@example.com",
                DOB = new DateTime(1980, 10, 10),
                Position = "HR ",
                JoiningDate = DateTime.Now
            };

            employeeRepositoryMock.Setup(repo => repo.AddEmployee(newEmployee)).Returns(true);
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var result = employeeService.AddEmployee(newEmployee);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void UpdateEmployee_ReturnsTrue_WhenEmployeeIsUpdatedSuccessfully()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            var existingEmployee = new Employee
            {
                EmployeeID = 1,
                Firstname = "haruki",
                Lastname = "Murakami",
                Email = "murakami@example.com",
                Position = "Author"
            };

            employeeRepositoryMock.Setup(repo => repo.UpdateEmployee(existingEmployee)).Returns(true);
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var result = employeeService.UpdateEmployee(existingEmployee);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveEmployee_ReturnsTrue_WhenEmployeeIsRemovedSuccessfully()
        {
            // Arrange
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            int employeeId = 1;

            employeeRepositoryMock.Setup(repo => repo.RemoveEmployee(employeeId)).Returns(true);
            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            // Act
            var result = employeeService.RemoveEmployee(employeeId);

            // Assert
            Assert.IsTrue(result);
        }





    }
}
