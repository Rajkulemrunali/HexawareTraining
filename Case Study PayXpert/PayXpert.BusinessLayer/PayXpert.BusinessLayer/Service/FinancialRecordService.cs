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
        public FinancialRecordService(IFinancialRecordRepository financialRecordRepository)
        {
            _financialRecordRepository = financialRecordRepository;
        }

        public bool AddFinancialRecord(int employeeId, string description, decimal amount, string recordType)
        {
           return  _financialRecordRepository.AddFinancialRecord(employeeId, description, amount, recordType);
        }

        public FinancialRecord GetFinancialRecordById(int recordId)
        {
            return _financialRecordRepository.GetFinancialRecordById(recordId);
        }
        public FinancialRecord GetFinancialRecordsForEmployee(int employeeId)
        {
            return _financialRecordRepository.GetFinancialRecordsForEmployee(employeeId);
        }
        public FinancialRecord GetFinancialRecordsForDate(DateTime recordDate)
        {
            return _financialRecordRepository.GetFinancialRecordsForDate(recordDate);
        }
    }
}
