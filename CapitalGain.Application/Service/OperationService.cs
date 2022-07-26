using CapitalGain.Application.Helper;
using CapitalGain.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapitalGain.Application.Service
{
    public class OperationService
    {
        private Domain.Stocks.OperationService _operationService;
        public OperationService(Domain.Stocks.OperationService operationService)
        {
            _operationService = operationService;
        }
        public List<TaxDTO> Process(string operationsJson)
        {
            var operationsDTO = operationsJson.Convert();

            var operationsEntity = operationsDTO.Convert();

            _operationService.Process(operationsEntity);

            return operationsEntity.Convert();

        }

        public string ProcessAsJson(string operationsJson)
        {
            return JsonSerializer.Serialize(Process(operationsJson));
        }
    }
}
