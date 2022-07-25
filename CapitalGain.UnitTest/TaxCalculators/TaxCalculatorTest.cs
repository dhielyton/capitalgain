using CapitalGain.Domain.Operations;
using CapitalGain.Domain.Stocks;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CapitalGain.UnitTest.TaxCalculators
{
    public class TaxCalculatorTest
    {
        [Theory]
        [InlineData(5000.00, 0.00,00.00)]
        [InlineData(1000.00, 0.00,00.00)]
        [InlineData(50000.00,0.00, 10000)]
        [InlineData(30000.00,25000.00,1000)]
        public void Calc_Tax(decimal profit,decimal loss ,decimal expectedResult)
        {
            TaxCalculator taxCalculator =  TaxCalculator.CreateTaxtCalulator();
            decimal valueTax = taxCalculator.CalcTaxValue(profit,loss);
            valueTax.Should().Be(expectedResult);


        }

       



    }
}
