using CapitalGain.Domain.Stocks;
using FluentAssertions;
using Xunit;

namespace CapitalGain.UnitTest.Stocks
{
    public class TaxCalculatorTest
    {
        [Theory]
        [InlineData(10000.00,5000.00, 0.00,00.00)]
        [InlineData(5000.00,1000.00, 0.00,00.00)]
        [InlineData(100000.00,50000.00,0.00, 10000)]
        [InlineData(50000.00,30000.00,25000.00,1000)]
        public void Calc_Tax(decimal totalOperacao ,decimal profit,decimal loss ,decimal expectedResult)
        {
            TaxCalculator taxCalculator =  TaxCalculator.CreateTaxtCalulator();
            profit -= loss;
            decimal valueTax = taxCalculator.CalcTaxValue(profit,totalOperacao);
            valueTax.Should().Be(expectedResult);


        }

    }
}
