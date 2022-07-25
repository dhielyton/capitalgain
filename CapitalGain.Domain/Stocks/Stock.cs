using CapitalGain.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Domain.Stocks
{
    public class Stock
    {

        public int Quantity { get; set; }
        public decimal WeightedAverage { get; set; }
        public decimal Loss { get; set; }
        public decimal Profit { get; set; }

        public void ProcessWeightedAverage(Operation operation)
        {
            if (operation.OperationType == OperationType.BUY)
                WeightedAverage = StockAverageCalculator.Average(Quantity, WeightedAverage, operation.Quantity, operation.UnitCost);
        }

        public void ProcessQuantity(Operation operation)
        {
            if (operation.OperationType == OperationType.BUY)
                Quantity += operation.Quantity;
            else
                Quantity -= operation.Quantity;
        }


        public void ProcessTax(Operation operation)
        {

        }
    }
}
