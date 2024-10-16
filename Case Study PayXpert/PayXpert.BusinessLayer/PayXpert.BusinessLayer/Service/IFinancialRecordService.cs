using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.DataAccessLayer;
using PayXpert.Exception;
using PayXpert.BusinessLayer.Repository;

namespace PayXpert.BusinessLayer.Service
{
    public interface IFinancialRecordService
    {
        bool AddFinancialRecord(int employeeId, string description, decimal amount, string recordType);
        FinancialRecord GetFinancialRecordById(int recordId);
        FinancialRecord GetFinancialRecordsForEmployee(int employeeId);
        FinancialRecord GetFinancialRecordsForDate(DateTime recordDate);
    }
}
