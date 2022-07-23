using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Operations
{
    public class TaxCalculator
    {

        public TaxCalculator()
        {
            PercentualTax = 20.00M;
            ExemptionLimit = 20000.00M;
        }

        public decimal ExemptionLimit { get; set; }
        public decimal PercentualTax { get; set; }
        public decimal CalcTaxValue(decimal profit)
        {
            if(profit >= ExemptionLimit)
            {
                return profit * (PercentualTax / 100);
            }

            return 0.00M;
        }
    }
}
