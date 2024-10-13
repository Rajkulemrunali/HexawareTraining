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
    public interface ITaxService
    {
        decimal CalculateTax(int employeeId, int taxYear);
        void GetTaxById(int taxId);
        void GetTaxesForEmployee(int employeeId);
        void GetTaxesForYear(int taxYear);
    }
}
