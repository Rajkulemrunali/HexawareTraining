using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PayXpert.BusinessLayer.Repository;
using PayXpert.BusinessLayer.Service;
using PayXpert.DataAccessLayer;
using PayXpert.Entity;
using System.IO;

namespace PayXpert.Test
{
    [TestFixture]
    public class Tax_Test
    {
        [Test]
        public void CalculateTax_Test()
        {
            TaxData taxData = new TaxData();

            decimal TaxRate = 0.20m;
            decimal TaxableAmount = 900000.00m;
            var Actual_Result= taxData.CalculateTax(3,2019);
            decimal Expected_Result = TaxRate * TaxableAmount;

            Assert.That(Expected_Result, Is.EqualTo(Actual_Result));
        }
        [Test]
        public void CalculateTaxForHighIncomeEmployee_Test()
        {
            TaxData taxData = new TaxData();

            decimal TaxRate = 0.20m;
            decimal TaxableAmount = 1300000.00m;
            var Actual_Result = taxData.CalculateTax(7, 2015);
            decimal Expected_Result = TaxRate * TaxableAmount;

            Assert.That(Expected_Result, Is.EqualTo(Actual_Result));
        }

    }
}
