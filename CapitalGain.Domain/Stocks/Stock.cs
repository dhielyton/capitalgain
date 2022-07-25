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

        public int Quantity { get; private set; }
        public decimal WeightedAverage { get; private set; }
        public decimal Loss { get; private set; }
        public decimal Profit { get; private set; }

        public void ProcessOperation(Operation operation)
        {
            ProcessProfitOrLoss(operation);
            ProcessTax(operation);
            ProcessWeightedAverage(operation);
            ProcessQuantity(operation);
        }
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
            operation.Tax = 0.00M;
            if (operation.OperationType == OperationType.BUY)
                return;
            operation.Tax = TaxCalculator.CreateTaxtCalulator().CalcTaxValue(Profit,Loss);


        }

        public void ProcessProfitOrLoss(Operation operation)
        {
            if (operation.OperationType == OperationType.SELL)
            {
                if (WeightedAverage < operation.UnitCost)
                {
                    var precentProfit = WeightedAverage / operation.UnitCost;
                    Profit = operation.Total * precentProfit;

                }
                else
                {
                    var percentLoss = operation.UnitCost / WeightedAverage;
                    Loss += percentLoss * (operation.Quantity * WeightedAverage);

                }
            }
        }
    }
}
