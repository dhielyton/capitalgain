using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Application.Model
{
    public class OperationDTO
    {
        [JsonProperty("operation")]
        public string OperationType { get; set; }

        [JsonProperty("unit-cost")]
        public decimal UnitCost { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
