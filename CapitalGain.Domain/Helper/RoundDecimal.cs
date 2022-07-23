using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Helper
{
    public static class RoundDecimal
    {
        public static decimal RoundValue(this decimal value)
        {
            return Math.Round(value,2);
        }
    }
}
