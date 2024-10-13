using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Entity
{
    public class FinancialRecord
    {
        public int RecordId { get; set; }
        public int EmployeeID { get; set; }
        public DateTime RecordDate { get; set; }    
        public string Description { get; set; }
        public decimal Amount { get; set; } 
        public string RecordType {  get; set; }

    }
}
