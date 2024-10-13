using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;
using PayXpert.DataAccessLayer;

namespace PayXpert.BusinessLayer.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        PayrollData payrollData=new PayrollData();
        public void GeneratePayroll(int payrollId,int employeeId, DateTime startDate, DateTime endDate)
        {
            Payroll payroll = new Payroll();
            payroll.PayrollID = payrollId;
            payroll.EmployeeID= employeeId;
            payroll.PayPeriodStartDate= startDate;
            payroll.PayPeriodEndDate= endDate;

            Console.WriteLine("Enter Basic Salary : ");
            payroll.BasicSalary=Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter OverTime Pay : ");
            payroll.OverTimePay = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter  Deductions : ");
            payroll.Deduction = Convert.ToDecimal(Console.ReadLine());

            payroll.Netsalary = (payroll.BasicSalary + payroll.OverTimePay) - payroll.Deduction;

            payrollData.GeneratePayroll(payroll);
            GetPayrollById(payrollId);
        }
        public void GetPayrollById(int payrollId)
        {
            payrollData.GetPayrollById(payrollId);
        }

        public void GetPayrollsForEmployee(int employeeId)
        {
            payrollData.GetPayrollsForEmployee(employeeId);
        }
        public void GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            payrollData.GetPayrollsForPeriod(startDate, endDate);
        }
    }
}
