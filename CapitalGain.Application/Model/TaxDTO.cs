
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapitalGain.Application.Model
{
    public class TaxDTO
    {
        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }
    }
}
