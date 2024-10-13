using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Entity
{
    public class Payroll
    {
        public int PayrollID { get ; set;}
        public int EmployeeID { get ; set;}
        public DateTime  PayPeriodStartDate {  get ; set;}
        public DateTime PayPeriodEndDate { get ; set;}
        public decimal BasicSalary { get ; set;}
        public decimal OverTimePay { get; set;}
        public decimal Deduction {  get; set;}
        public decimal Netsalary { get; set;}
    }
}
