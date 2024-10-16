using PayXpert.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.DataAccessLayer;
using PayXpert.Exception;

namespace PayXpert.BusinessLayer.Repository
{
    public interface ITaxRepository
    {
        decimal CalculateTax(int employeeId, int taxYear);
        Tax GetTaxById(int taxId);
        Tax GetTaxesForEmployee(int employeeId);
        Tax GetTaxesForYear(int taxYear);
    }
}
