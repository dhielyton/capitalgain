using CapitalGain.Domain.Stocks;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CapitalGain.UnitTest.Stocks
{
    public class StockTest
    {

        [Fact]
        public void Process_weighted_average_stocks_operations()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 20.00M, Quantity = 10, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 15.00M, Quantity = 5, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 5, Stock = stock });

            foreach (var operation in operations)
            {
                operation.Process();
            }
            stock.WeightedAverage.Should().Be(15.00M);

        }


        [Fact]
        public void Process_quantity_total_stocks()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 20.00M, Quantity = 10, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 15.00M, Quantity = 5, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 5, Stock = stock });

            foreach (var operation in operations)
            {
                operation.Process();
            }
            stock.Quantity.Should().Be(10);

        }

        [Fact]
        public void Process_tax_operations()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 10000, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 20.00M, Quantity = 5000, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 5.00M, Quantity = 5000 , Stock = stock });

            foreach (var operation in operations)
            {
                operation.Process();
            }

            var arrayResults = operations.ToArray();
            arrayResults[0].Tax.Should().Be(0.00M);
            arrayResults[1].Tax.Should().Be(10000.00M);
            arrayResults[2].Tax.Should().Be(0.00M);
        }

        [Fact]
        public void Process_profit_or_loss()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 10000, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 20.00M, Quantity = 5000, Stock = stock });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 5.00M, Quantity = 5000, Stock = stock });

            foreach (var operation in operations)
            {
                operation.Process();
            }
            stock.Profit.Should().Be(0.00M);
            stock.Loss.Should().Be(25000.00M);

        }
    }
}
