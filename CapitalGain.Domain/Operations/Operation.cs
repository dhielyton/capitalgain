using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Operations
{
    public class Operation
    {
        [JsonProperty("operation")]
        public string OperationType { get; set; }

        [JsonProperty("unit-cost")]
        public double UnitCost { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
