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
        void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType);
        void GetFinancialRecordById(int recordId);
        void GetFinancialRecordsForEmployee(int employeeId);
        void GetFinancialRecordsForDate(DateTime recordDate);
    }
}
