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
        public TaxService(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }
        public decimal CalculateTax(int employeeId, int taxYear)
        {
           return  _taxRepository.CalculateTax(employeeId, taxYear);
        }

        public void GetTaxById(int taxId)
        {
            _taxRepository.GetTaxById(taxId);
        }
        public void GetTaxesForEmployee(int employeeId)
        {
            _taxRepository.GetTaxesForEmployee(employeeId);
        }
        public void GetTaxesForYear(int taxYear)
        {
            _taxRepository.GetTaxesForYear(taxYear);
        }
    }
}
