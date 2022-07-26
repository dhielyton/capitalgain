using CapitalGain.Domain.Helper;
using System;

namespace CapitalGain.Domain.Stocks
{
    public class Stock
    {

        public int Quantity { get; private set; }
        public decimal WeightedAveragePrice { get; private set; }
        public decimal Loss { get; private set; }
        public decimal Profit { get; private set; }

        public void ProcessOperation(Operation operation)
        {
            ProcessProfitOrLoss(operation);
            ProcessTax(operation);
            ProcessWeightedAverage(operation);
            ProcessQuantity(operation);
        }
        private void ProcessWeightedAverage(Operation operation)
        {
            if (operation.OperationType == OperationType.BUY)
                WeightedAveragePrice = StockAverageCalculator.Average(Quantity, WeightedAveragePrice, operation.Quantity, operation.UnitCost);
        }

        private void ProcessQuantity(Operation operation)
        {
            if (operation.OperationType == OperationType.BUY)
                Quantity += operation.Quantity;
            else
                Quantity -= operation.Quantity;
        }


        private void ProcessTax(Operation operation)
        {
            operation.Tax = 0.00M;
            if (operation.OperationType == OperationType.BUY)
                return;
            var tax = TaxCalculator.CreateTaxtCalulator().CalcTaxValue(Profit, operation.Total);

            if (tax > 0.00M)
            {
                Profit = 0.00M;
                Loss = 0.00M;
            }

            operation.Tax = tax;

        }

        private void ProcessProfitOrLoss(Operation operation)
        {
            if (operation.OperationType == OperationType.SELL)
            {
                if (WeightedAveragePrice == operation.UnitCost)
                    return;

                var capitalGain = CapitalGainCalculator.Calc(WeightedAveragePrice, operation.UnitCost, operation.Quantity, operation.Total);

                if (capitalGain > 0.00M)
                {
                    Profit = capitalGain;
                }
                else
                    Loss += Math.Abs(capitalGain);

                if (Profit > Loss)
                {
                    Profit -= Loss;
                    Loss = 0.00M;
                    return;
                }

                if (Profit < Loss)
                {
                    Loss -= Profit;
                    Profit = 0.00M;
                    return;
                }

                Profit = 0.00M;
                Loss = 0.00M;


            }
        }
    }
}
