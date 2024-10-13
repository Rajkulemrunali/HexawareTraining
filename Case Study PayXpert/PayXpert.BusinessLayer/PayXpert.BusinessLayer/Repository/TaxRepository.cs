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
    public class TaxRepository : ITaxRepository
    {
        TaxData taxData =new TaxData();
        public decimal CalculateTax(int employeeId, int taxYear)
        {
           return taxData.CalculateTax(employeeId, taxYear);
        }

        public void GetTaxById(int taxId)
        {
            taxData.GetTaxById(taxId);
        }
        public void GetTaxesForEmployee(int employeeId)
        {
            taxData.GetTaxesForEmployee(employeeId);
        }
        public void GetTaxesForYear(int taxYear)
        {
            taxData.GetTaxesForYear(taxYear);
        }
    }
}
