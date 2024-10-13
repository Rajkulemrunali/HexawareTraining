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
    public interface IPayrollRepository
    {
        void GeneratePayroll(int payrollId, int employeeId, DateTime startDate, DateTime endDate);
        void GetPayrollById(int payrollId);
        void GetPayrollsForEmployee(int employeeId);
        void GetPayrollsForPeriod(DateTime startDate, DateTime endDate);
    }
}
