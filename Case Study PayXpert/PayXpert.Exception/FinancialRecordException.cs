using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayXpert.Exception 
{
    public class FinancialRecordException : System.Exception
    {
        public FinancialRecordException(): base() { }
        public FinancialRecordException(string message) : base(message) { }
        public FinancialRecordException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}
