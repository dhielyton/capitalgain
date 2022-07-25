using CapitalGain.Domain.Stocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Operations
{
    public class Operation
    {
        public Operation()
        {
            Stock = new Stock();
        }
        public OperationType OperationType { get; set; }
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; private set; }
        public decimal Tax { get; set; }

        public Stock Stock { get; set; }

        public void Process()
        {
            Total = Quantity * UnitCost;
            Stock.ProcessOperation(this);
            
        }

    }
}
