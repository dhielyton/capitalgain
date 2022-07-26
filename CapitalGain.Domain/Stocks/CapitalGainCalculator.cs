using CapitalGain.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Stocks
{
    public static class CapitalGainCalculator
    {
        public static decimal Calc(decimal weightedAveragePrice, decimal priceSell, int quantitySell, decimal totalSell)
        {
            var capitalGain = 0.00M;
            
            if (weightedAveragePrice < priceSell)
            {
                var precentProfit = 1.00M - (weightedAveragePrice / priceSell);
                capitalGain = (totalSell * precentProfit);
            }
            else
                capitalGain =  (totalSell) - (quantitySell * weightedAveragePrice);

            return capitalGain.RoundValue();
        }
    }
}
