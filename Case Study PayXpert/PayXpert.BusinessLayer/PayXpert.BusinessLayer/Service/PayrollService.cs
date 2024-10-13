using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;
using PayXpert.DataAccessLayer;
using PayXpert.BusinessLayer.Repository;


namespace PayXpert.BusinessLayer.Service
{
    public class PayrollService : IPayrollService
    {
        IPayrollRepository _payrollRepository;
        public PayrollService(PayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public void GeneratePayroll(int payrollId, int employeeId, DateTime startDate, DateTime endDate)
        {
            _payrollRepository.GeneratePayroll(payrollId, employeeId, startDate, endDate);
        }
        public void GetPayrollById(int payrollId)
        {
            _payrollRepository.GetPayrollById(payrollId);
        }

        public void GetPayrollsForEmployee(int employeeId)
        {
            _payrollRepository.GetPayrollsForEmployee(employeeId);
        }
        public void GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            _payrollRepository.GetPayrollsForPeriod(startDate, endDate);
        }
    }
}
