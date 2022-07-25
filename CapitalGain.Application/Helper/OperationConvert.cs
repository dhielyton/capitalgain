using CapitalGain.Application.Model;
using CapitalGain.Domain.Operations;
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

        public static Operation Convert(this OperationDTO operationDTO)
        {
            var operation = new Operation();
            switch (operationDTO.OperationType.ToLower())
            {
                case "sell":
                    operation.OperationType = OperationType.SELL;
                    break;
                case "buy":
                    operation.OperationType = OperationType.BUY;
                    break;
            }
            operation.Quantity = operationDTO.Quantity;
            operation.UnitCost = operationDTO.UnitCost;
            return operation;
        }

        public static TaxDTO Convert(this Operation operation)
        {
            return new TaxDTO { Tax = operation.Tax };
        }
    }
}
