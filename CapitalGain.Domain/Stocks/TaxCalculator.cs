using CapitalGain.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Stocks
{
    public class TaxCalculator
    {
        public TaxCalculator(decimal exemptionLimit, decimal percentualTax)
        {
            ExemptionLimit = exemptionLimit;
            PercentualTax = percentualTax;
        }

        public decimal ExemptionLimit { get; private set; }
        public decimal PercentualTax { get; private set; }
        public decimal CalcTaxValue(decimal profit, decimal loss)
        {
            
            if(profit >= ExemptionLimit)
            {
                return ((profit-loss) * (PercentualTax / 100)).RoundValue();
            }

            return 0.00M;
        }

        public static TaxCalculator CreateTaxtCalulator()
        {
            TaxCalculator taxCalculator = new TaxCalculator(20000M, 20.00M);
            return taxCalculator;
        }
    }
}
