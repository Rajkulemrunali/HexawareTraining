using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.Exception;
using PayXpert.DataAccessLayer;
using PayXpert.BusinessLayer.Repository;

namespace PayXpert.BusinessLayer.Service
{
    public interface IPayrollService
    {
        void GeneratePayroll(int payrollId, int employeeId, DateTime startDate, DateTime endDate);
        void GetPayrollById(int payrollId);
        void GetPayrollsForEmployee(int employeeId);
        void GetPayrollsForPeriod(DateTime startDate, DateTime endDate);
    }
}
