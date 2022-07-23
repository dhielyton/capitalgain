using CapitalGain.Application.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Application.Helper
{
    public static class OperationConvert
    {
        public static List<OperationDTO> Convert(this string json)
        {
            var operation = JsonConvert.DeserializeObject<List<OperationDTO>>(json);
            
            return operation;
        }
    }
}
