using CapitalGain.Domain.Stocks;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CapitalGain.UnitTest.Stocks
{
    public class CapitalGainCalculatorTest
    {
        [Theory]
        [InlineData(10.00, 20.00, 5000, 100000,50000.00)]
        [InlineData(10.00, 5.00, 5000, 25000.00, -25000.00)]
        public void Calc_capital_gain(decimal weightedAveragePrice, decimal uniCost, int quantity, decimal total, decimal expectedResult)
        {
            var capitalGain =  CapitalGainCalculator.Calc(weightedAveragePrice, uniCost, quantity, total);
            capitalGain.Should().Be(expectedResult);

        }
}
}
