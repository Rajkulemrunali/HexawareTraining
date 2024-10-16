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
        public PayrollService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public bool GeneratePayroll(Payroll payroll)
        {
            return _payrollRepository.GeneratePayroll(payroll);
        }
        public Payroll GetPayrollById(int payrollId)
        {
            return _payrollRepository.GetPayrollById(payrollId);
        }

        public List<Payroll> GetPayrollsForEmployee(int employeeId)
        {
            return _payrollRepository.GetPayrollsForEmployee(employeeId);
        }
        public List<Payroll> GetPayrollsForPeriod(DateTime startDate, DateTime endDate)
        {
            return _payrollRepository.GetPayrollsForPeriod(startDate, endDate);
        }

        
    }
}
