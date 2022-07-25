using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CapitalGain.Domain.Stocks;
using CapitalGain.Domain.Operations;

namespace CapitalGain.UnitTest.StockAvarageCalculators
{
    public class StockAvarageCalculatorTest
    {
        [Theory]
        [InlineData(5,20.00,5,10.00,15.00)]
        [InlineData(15,84.72,30,65.32,71.79)]
        [InlineData(10,20.00,5,10.00,16.67)]
        public void Calc_stock_avarage_with_sucess(int currentStockAmount, decimal currentWeightMedia, int stockQuantity, decimal stockPurchaseValue, decimal expectedResult)
        {
            var newWeightMedia = StockAverageCalculator.Average(currentStockAmount, currentWeightMedia, stockQuantity, stockPurchaseValue);
            newWeightMedia.Should().Be(expectedResult);
        }

       
    }

    
}
