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
            TaxCalculator taxCalculator = new TaxCalculator();
            decimal valueTax = taxCalculator.CalcTaxValue(profit,loss);
            valueTax.Should().Be(expectedResult);


        }

        [Fact]
        public void Calc_Tax_operations()
        {
            Stock stockAverage = new Stock();


            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, Quantity = 1000, UnitCost = 50.00M });
            operations.Add(new Operation { OperationType = OperationType.BUY, Quantity = 1000, UnitCost = 50.00M });


        }



    }
}
