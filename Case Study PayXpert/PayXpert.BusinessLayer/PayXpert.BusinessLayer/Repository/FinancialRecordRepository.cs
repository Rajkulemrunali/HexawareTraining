using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.DataAccessLayer;
using PayXpert.Exception;

namespace PayXpert.BusinessLayer.Repository
{
    public class FinancialRecordRepository : IFinancialRecordRepository
    {
        FinancialRecordData financialRecordData = new FinancialRecordData();
        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            financialRecordData.AddFinancialRecord(employeeId, description, amount, recordType);
        }

        public void GetFinancialRecordById(int recordId)
        {
            financialRecordData.GetFinancialRecordById(recordId);
        }
        public void GetFinancialRecordsForEmployee(int employeeId)
        {
            financialRecordData.GetFinancialRecordsForEmployee(employeeId);
        }
        public void GetFinancialRecordsForDate(DateTime recordDate)
        {
            financialRecordData.GetFinancialRecordsForDate((DateTime)recordDate);
        }
    }
}
