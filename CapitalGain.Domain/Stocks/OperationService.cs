using CapitalGain.Domain.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Stocks
{
    public class OperationService
    {

        public List<Operation> Process(List<Operation> operations)
        {
            var stock = new Stock(); 
            foreach (var operation in operations)
            {
                operation.Stock = stock;
                operation.Process();
            }
            return operations;
        }
    }
}
