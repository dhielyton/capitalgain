using CapitalGain.Application.Model;
using CapitalGain.Domain.Stocks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CapitalGain.Application.Helper
{
    public static class OperationConvert
    {
        public static List<OperationDTO> Convert(this string json)
        {
            var operation = JsonConvert.DeserializeObject<List<OperationDTO>>(json);
            
            return operation;
        }

        public static List<Operation> Convert(this List<OperationDTO> operationsDTO)
        {
            var operationsEntity = new List<Operation>();
            foreach (var operationDTO in operationsDTO)
            {
                operationsEntity.Add(operationDTO.Convert());
            }
            return operationsEntity;
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

        public static List<TaxDTO> Convert(this List<Operation> operations)
        {
           return operations.Select(o => new TaxDTO { Tax = o.Tax }).ToList();
        }
    }
}
