using PayXpert.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.Entity;
using PayXpert.DataAccessLayer;
using PayXpert.Exception;


namespace PayXpert.BusinessLayer.Service
{
    public class TaxService : ITaxService
    {
        ITaxRepository _taxRepository;
        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }
        public decimal CalculateTax(int employeeId, int taxYear)
        {
           return  _taxRepository.CalculateTax(employeeId, taxYear);
        }

        public Tax GetTaxById(int taxId)
        {
            return _taxRepository.GetTaxById(taxId);
        }
        public Tax GetTaxesForEmployee(int employeeId)
        {
            return _taxRepository.GetTaxesForEmployee(employeeId);
        }
        public Tax GetTaxesForYear(int taxYear)
        {
            return _taxRepository.GetTaxesForYear(taxYear);
        }
    }
}
