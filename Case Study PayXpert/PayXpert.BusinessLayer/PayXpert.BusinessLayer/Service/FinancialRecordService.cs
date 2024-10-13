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
    public class FinancialRecordService : IFinancialRecordService
    {
        IFinancialRecordRepository _financialRecordRepository;
        public FinancialRecordService(FinancialRecordRepository financialRecordRepository)
        {
            _financialRecordRepository = financialRecordRepository;
        }

        public void AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
            _financialRecordRepository.AddFinancialRecord(employeeId, description, amount, recordType);
        }

        public void GetFinancialRecordById(int recordId)
        {
            _financialRecordRepository.GetFinancialRecordById(recordId);
        }
        public void GetFinancialRecordsForEmployee(int employeeId)
        {
            _financialRecordRepository.GetFinancialRecordsForEmployee(employeeId);
        }
        public void GetFinancialRecordsForDate(DateTime recordDate)
        {
            _financialRecordRepository.GetFinancialRecordsForDate(recordDate);
        }
    }
}
