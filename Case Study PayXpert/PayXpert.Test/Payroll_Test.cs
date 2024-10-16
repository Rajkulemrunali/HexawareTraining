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

namespace PayXpert.Test
{
    [TestFixture]
    public class Payroll_Test
    {
        [Test]
        public void GeneratePayroll_ValidData_ReturnsTrue()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            var payroll = new Payroll
            {
                PayrollID = 1,
                EmployeeID = 1,
                PayPeriodStartDate = DateTime.Now.AddDays(-30),
                PayPeriodEndDate = DateTime.Now,
                BasicSalary = 50000m,
                OverTimePay = 5000m,
                Deduction = 2000m,
                Netsalary = 53000m
            };

            payrollRepositoryMock.Setup(repo => repo.GeneratePayroll(payroll)).Returns(true);

            // Act
            var result = payrollRepositoryMock.Object.GeneratePayroll(payroll);

            // Assert
            Assert.IsTrue(result);
            payrollRepositoryMock.Verify(repo => repo.GeneratePayroll(payroll), Times.Once);
        }

        [Test]
        public void GeneratePayroll_DatabaseConnectionFailure_ThrowsException()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            var payroll = new Payroll
            {
                PayrollID = 1,
                EmployeeID = 1,
                PayPeriodStartDate = DateTime.Now.AddDays(-30),
                PayPeriodEndDate = DateTime.Now,
                BasicSalary = 50000m,
                OverTimePay = 5000m,
                Deduction = 2000m,
                Netsalary = 53000m
            };

            // Simulating a database connection failure
            payrollRepositoryMock.Setup(repo => repo.GeneratePayroll(payroll)).Throws(new DataBaseConnectionException("Database connection failed."));

            // Act & Assert
            Assert.Throws<DataBaseConnectionException>(() => payrollRepositoryMock.Object.GeneratePayroll(payroll));
        }


        [Test]
        public void GetPayrollById_ValidId_ReturnsPayroll()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            int payrollId = 1;

            var payroll = new Payroll
            {
                PayrollID = payrollId,
                EmployeeID = 1,
                PayPeriodStartDate = DateTime.Now.AddDays(-30),
                PayPeriodEndDate = DateTime.Now,
                BasicSalary = 50000m,
                OverTimePay = 5000m,
                Deduction = 2000m,
                Netsalary = 53000m
            };

            payrollRepositoryMock.Setup(repo => repo.GetPayrollById(payrollId)).Returns(payroll);

            // Act
            var result = payrollRepositoryMock.Object.GetPayrollById(payrollId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(payrollId, result.PayrollID);
            payrollRepositoryMock.Verify(repo => repo.GetPayrollById(payrollId), Times.Once);
        }

        [Test]
        public void GetPayrollById_InvalidId_ThrowsException()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            int payrollId = 999; // Non-existent payroll ID

            payrollRepositoryMock.Setup(repo => repo.GetPayrollById(payrollId)).Throws(new PayrollGenerationException($"Payroll with ID {payrollId} not found."));

            // Act & Assert
            Assert.Throws<PayrollGenerationException>(() => payrollRepositoryMock.Object.GetPayrollById(payrollId));
        }


        [Test]
        public void GetPayrollsForEmployee_ValidEmployeeId_ReturnsPayrollList()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            int employeeId = 1;

            var payrolls = new List<Payroll>
        {
            new Payroll
            {
                PayrollID = 1,
                EmployeeID = employeeId,
                PayPeriodStartDate = DateTime.Now.AddDays(-30),
                PayPeriodEndDate = DateTime.Now,
                BasicSalary = 50000m,
                OverTimePay = 5000m,
                Deduction = 2000m,
                Netsalary = 53000m
            }
        };

            payrollRepositoryMock.Setup(repo => repo.GetPayrollsForEmployee(employeeId)).Returns(payrolls);

            // Act
            var result = payrollRepositoryMock.Object.GetPayrollsForEmployee(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(employeeId, result[0].EmployeeID);
            payrollRepositoryMock.Verify(repo => repo.GetPayrollsForEmployee(employeeId), Times.Once);
        }

        [Test]
        public void GetPayrollsForEmployee_InvalidEmployeeId_ThrowsException()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            int employeeId = 999; // Non-existent employee ID

            payrollRepositoryMock.Setup(repo => repo.GetPayrollsForEmployee(employeeId)).Throws(new PayrollGenerationException($"No payrolls found for employee with ID {employeeId}."));

            // Act & Assert
            Assert.Throws<PayrollGenerationException>(() => payrollRepositoryMock.Object.GetPayrollsForEmployee(employeeId));
        }


        [Test]
        public void GetPayrollsForPeriod_ValidPeriod_ReturnsPayrollList()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            var payrolls = new List<Payroll>
        {
            new Payroll
            {
                PayrollID = 1,
                EmployeeID = 1,
                PayPeriodStartDate = startDate,
                PayPeriodEndDate = endDate,
                BasicSalary = 50000m,
                OverTimePay = 5000m,
                Deduction = 2000m,
                Netsalary = 53000m
            }
        };

            payrollRepositoryMock.Setup(repo => repo.GetPayrollsForPeriod(startDate, endDate)).Returns(payrolls);

            // Act
            var result = payrollRepositoryMock.Object.GetPayrollsForPeriod(startDate, endDate);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            payrollRepositoryMock.Verify(repo => repo.GetPayrollsForPeriod(startDate, endDate), Times.Once);
        }

        [Test]
        public void GetPayrollsForPeriod_NoPayrolls_ThrowsException()
        {
            // Arrange
            var payrollRepositoryMock = new Mock<IPayrollRepository>();
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            payrollRepositoryMock.Setup(repo => repo.GetPayrollsForPeriod(startDate, endDate)).Throws(new PayrollGenerationException($"No payrolls found for the period {startDate} to {endDate}."));

            // Act & Assert
            Assert.Throws<PayrollGenerationException>(() => payrollRepositoryMock.Object.GetPayrollsForPeriod(startDate, endDate));
        }

    }



}
