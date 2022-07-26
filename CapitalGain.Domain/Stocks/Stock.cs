using CapitalGain.Domain.Helper;

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
            var tax = TaxCalculator.CreateTaxtCalulator().CalcTaxValue(Profit, operation.Total);

            if (tax > 0.00M)
            {
                Profit = 0.00M;
                Loss = 0.00M;
            }

            operation.Tax = tax;

        }

        public void ProcessProfitOrLoss(Operation operation)
        {
            if (operation.OperationType == OperationType.SELL)
            {
                if (WeightedAverage == operation.UnitCost)
                    return;

                if (WeightedAverage < operation.UnitCost)
                {
                    var precentProfit = 1.00M - (WeightedAverage / operation.UnitCost);
                    Profit = (operation.Total * precentProfit).RoundValue();
                }
                else
                    Loss += (operation.Quantity * WeightedAverage) - (operation.Total);
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
