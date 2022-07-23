using CapitalGain.Domain.Operations;
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
        [InlineData(5000.00, 00.00)]
        [InlineData(50000.00, 10000)]
        public void Calc_Tax(decimal profit, decimal expectedResult)
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            decimal valueTax = taxCalculator.CalcTaxValue(profit);
            valueTax.Should().Be(expectedResult);


        }

    }
}
