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
    public class Tax_Test
    {

        [Test]
        public void CalculateTax_ReturnsCorrectTaxAmount()
        {
            // Arrange
            var taxRepositoryMock = new Mock<ITaxRepository>(); // Mocking the repository
            var employeeId = 1;
            var taxYear = 2023;
            decimal expectedTaxAmount = 2000m; // Example expected result

            // Mocking the CalculateTax method to return the expected tax amount
            taxRepositoryMock.Setup(repo => repo.CalculateTax(employeeId, taxYear))
                .Returns(expectedTaxAmount);

            var taxService = new TaxService(taxRepositoryMock.Object); // Assuming there's a TaxService

            // Act
            var result = taxService.CalculateTax(employeeId, taxYear); // Act by calling the method

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTaxAmount, result);

            // Verify that the method was called exactly once
            taxRepositoryMock.Verify(repo => repo.CalculateTax(employeeId, taxYear), Times.Once);
        }

        [Test]
        public void GetTaxById_ReturnsCorrectTax()
        {
            // Arrange
            var taxRepositoryMock = new Mock<ITaxRepository>(); // Mocking the repository
            int taxId = 1;

            // Creating a mock tax object
            var mockTax = new Tax
            {
                TaxID = taxId,
                EmployeeID = 1,
                TaxYear = 2023,
                TaxableIncome = 50000m,
                TaxAmount = 10000m
            };

            // Setting up the mock repository to return the mock tax when GetTaxById is called
            taxRepositoryMock.Setup(repo => repo.GetTaxById(taxId)).Returns(mockTax);

            var taxService = new TaxService(taxRepositoryMock.Object); // Assuming there's a TaxService

            // Act
            var result = taxService.GetTaxById(taxId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(taxId, result.TaxID);
            Assert.AreEqual(10000m, result.TaxAmount);

            // Verify that the method was called exactly once
            taxRepositoryMock.Verify(repo => repo.GetTaxById(taxId), Times.Once);
        }

      
        [Test]
        public void GetTaxesForEmployee_ReturnsCorrectTax()
            {
                // Arrange
                var taxRepositoryMock = new Mock<ITaxRepository>(); // Mocking the repository
                int employeeId = 1;

                // Creating a mock tax object
                var mockTax = new Tax
                {
                    TaxID = 1,
                    EmployeeID = employeeId,
                    TaxYear = 2023,
                    TaxableIncome = 60000m,
                    TaxAmount = 12000m
                };

                // Setting up the mock repository to return the mock tax when GetTaxesForEmployee is called
                taxRepositoryMock.Setup(repo => repo.GetTaxesForEmployee(employeeId)).Returns(mockTax);

                var taxService = new TaxService(taxRepositoryMock.Object); // Assuming you have a TaxService

                // Act
                var result = taxService.GetTaxesForEmployee(employeeId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(employeeId, result.EmployeeID);
                Assert.AreEqual(12000m, result.TaxAmount);

                // Verify that the method was called exactly once
                taxRepositoryMock.Verify(repo => repo.GetTaxesForEmployee(employeeId), Times.Once);
            }

        [Test]
        public void GetTaxesForYear_ReturnsCorrectTax()
        {
            // Arrange
            var taxRepositoryMock = new Mock<ITaxRepository>(); // Mocking the repository
            int taxYear = 2023;

            // Creating a mock tax object
            var mockTax = new Tax
            {
                TaxID = 1,
                EmployeeID = 1,
                TaxYear = taxYear,
                TaxableIncome = 70000m,
                TaxAmount = 14000m
            };

            // Setting up the mock repository to return the mock tax when GetTaxesForYear is called
            taxRepositoryMock.Setup(repo => repo.GetTaxesForYear(taxYear)).Returns(mockTax);

            var taxService = new TaxService(taxRepositoryMock.Object); // Assuming you have a TaxService

            // Act
            var result = taxService.GetTaxesForYear(taxYear);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(taxYear, result.TaxYear);
            Assert.AreEqual(14000m, result.TaxAmount);

            // Verify that the method was called exactly once
            taxRepositoryMock.Verify(repo => repo.GetTaxesForYear(taxYear), Times.Once);
        }


        /*
          [Test]
        public void CalculateTax_Test()
        {
            TaxRepository taxRepository = new TaxRepository();
            TaxService taxService   = new TaxService(taxRepository);

            decimal TaxRate = 0.20m;
            decimal TaxableAmount = 900000.00m;
            var Actual_Result= taxService.CalculateTax(3,2019);
            decimal Expected_Result = TaxRate * TaxableAmount;

            Assert.That(Expected_Result, Is.EqualTo(Actual_Result));
        }
        [Test]
        public void CalculateTaxForHighIncomeEmployee_Test()
        {
            TaxRepository taxRepository = new TaxRepository();
            TaxService taxService = new TaxService(taxRepository);

            decimal TaxRate = 0.20m;
            decimal TaxableAmount = 1300000.00m;
            var Actual_Result = taxService.CalculateTax(7, 2015);
            decimal Expected_Result = TaxRate * TaxableAmount;

            Assert.That(Expected_Result, Is.EqualTo(Actual_Result));
        }
        */

    }
}
