using CapitalGain.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Stocks
{
    public static class StockAverageCalculator
    {
        public static decimal Average(int currentStockAmount, decimal currentWeightMedia, int stockQuantity, decimal stockPurchaseValue)
        {
            var average = ((currentStockAmount * currentWeightMedia) + (stockQuantity * stockPurchaseValue)) / (currentStockAmount + stockQuantity);
            return average.RoundValue();
        }
    }
}
