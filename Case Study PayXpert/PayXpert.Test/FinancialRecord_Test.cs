using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using PayXpert.BusinessLayer.Repository;
using PayXpert.Entity;
using PayXpert.Exception;
using System.Data.SqlClient;
using PayXpert.BusinessLayer.Service;

namespace PayXpert.Test
{
    [TestFixture]
    public class FinancialRecord_Test
    {

        private Mock<IFinancialRecordRepository> _financialRecordRepositoryMock;
        private FinancialRecordService _financialRecordService; // Assuming you have a service class

        [SetUp]
        public void Setup()
        {
            _financialRecordRepositoryMock = new Mock<IFinancialRecordRepository>();
            _financialRecordService = new FinancialRecordService(_financialRecordRepositoryMock.Object);
        }

        [Test]
        public void AddFinancialRecord_ReturnsTrue_WhenRecordIsAddedSuccessfully()
        {
            // Arrange
            int employeeId = 1;
            string description = "Salary Payment";
            decimal amount = 5000m;
            string recordType = "Credit";

            // Mocking the AddFinancialRecord method to return true
            _financialRecordRepositoryMock
                .Setup(repo => repo.AddFinancialRecord(employeeId, description, amount, recordType))
                .Returns(true);

            // Act
            var result = _financialRecordService.AddFinancialRecord(employeeId, description, amount, recordType); // Assuming you have a method in the service

            // Assert
            Assert.IsTrue(result);
            _financialRecordRepositoryMock.Verify(repo => repo.AddFinancialRecord(employeeId, description, amount, recordType), Times.Once);
        }

        [Test]
        public void GetFinancialRecordById_ReturnsFinancialRecord_WhenRecordExists()
        {
            // Arrange
            int recordId = 1;
            var expectedRecord = new FinancialRecord
            {
                RecordId = recordId,
                EmployeeID = 1,
                RecordDate = DateTime.Now,
                Amount = 5000m,
                Description = "Salary Payment",
                RecordType = "Credit"
            };

            // Mocking the GetFinancialRecordById method to return a record
            _financialRecordRepositoryMock
                .Setup(repo => repo.GetFinancialRecordById(recordId))
                .Returns(expectedRecord);

            // Act
            var result = _financialRecordService.GetFinancialRecordById(recordId); // Assuming you have a method in the service

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRecord.RecordId, result.RecordId);
            Assert.AreEqual(expectedRecord.Description, result.Description);
            _financialRecordRepositoryMock.Verify(repo => repo.GetFinancialRecordById(recordId), Times.Once);
        }


        [Test]
        public void GetFinancialRecordsForEmployee_ReturnsFinancialRecord_WhenRecordsExist()
        {
            // Arrange
            int employeeId = 1;
            var expectedRecord = new FinancialRecord
            {
                RecordId = 1,
                EmployeeID = employeeId,
                RecordDate = DateTime.Now,
                Amount = 5000m,
                Description = "Salary Payment",
                RecordType = "Credit"
            };

            // Mocking the GetFinancialRecordsForEmployee method to return a record
            _financialRecordRepositoryMock
                .Setup(repo => repo.GetFinancialRecordsForEmployee(employeeId))
                .Returns(expectedRecord);

            // Act
            var result = _financialRecordService.GetFinancialRecordsForEmployee(employeeId); // Assuming you have a method in the service

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRecord.RecordId, result.RecordId);
            Assert.AreEqual(expectedRecord.Description, result.Description);
            _financialRecordRepositoryMock.Verify(repo => repo.GetFinancialRecordsForEmployee(employeeId), Times.Once);
        }


        [Test]
        public void GetFinancialRecordsForDate_ReturnsFinancialRecord_WhenRecordExists()
        {
            // Arrange
            DateTime recordDate = DateTime.Now.Date;
            var expectedRecord = new FinancialRecord
            {
                RecordId = 1,
                EmployeeID = 1,
                RecordDate = recordDate,
                Amount = 5000m,
                Description = "Salary Payment",
                RecordType = "Credit"
            };

            // Mocking the GetFinancialRecordsForDate method to return a record
            _financialRecordRepositoryMock
                .Setup(repo => repo.GetFinancialRecordsForDate(recordDate))
                .Returns(expectedRecord);

            // Act
            var result = _financialRecordService.GetFinancialRecordsForDate(recordDate); // Assuming you have a method in the service

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRecord.RecordId, result.RecordId);
            Assert.AreEqual(expectedRecord.Description, result.Description);
            _financialRecordRepositoryMock.Verify(repo => repo.GetFinancialRecordsForDate(recordDate), Times.Once);
        }
    }
}
