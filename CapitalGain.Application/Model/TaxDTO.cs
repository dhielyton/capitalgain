using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Application.Model
{
    public class TaxDTO
    {
        [JsonProperty("tax")]
        public decimal Tax { get; set; }
    }
}
