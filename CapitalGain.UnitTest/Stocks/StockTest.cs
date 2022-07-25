using CapitalGain.Domain.Operations;
using CapitalGain.Domain.Stocks;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 20.00M, Quantity = 10 });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 15.00M, Quantity = 5 });
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 5 });

            foreach (var operation in operations)
            {
                stock.ProcessWeightedAverage(operation);
                stock.ProcessQuantity(operation);
            }

            stock.WeightedAverage.Should().Be(15.00M);

        }


        [Fact]
        public void Process_quantity_total_stocks()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 20.00M, Quantity = 10 });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 15.00M, Quantity = 5 });
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 5 });

            foreach (var operation in operations)
            {
               
                stock.ProcessQuantity(operation);
            }

            stock.Quantity.Should().Be(10);

        }

        [Fact]
        public void Process_tax_operations()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 10000 });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 20.00M, Quantity = 5000 });
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 5.00M, Quantity = 5000 });

            foreach (var operation in operations)
            {
                stock.ProcessTax(operation);
                stock.ProcessQuantity(operation);
            }

            stock.Quantity.Should().Be(10);

        }

        [Fact]
        public void Process_profit_or_loss()
        {
            var stock = new Stock();
            List<Operation> operations = new List<Operation>();
            operations.Add(new Operation { OperationType = OperationType.BUY, UnitCost = 10.00M, Quantity = 10000 });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 20.00M, Quantity = 5000 });
            operations.Add(new Operation { OperationType = OperationType.SELL, UnitCost = 5.00M, Quantity = 5000 });
            
            foreach (var operation in operations)
            {
                operation.Process();

                stock.ProcessProfitOrLoss(operation);
                stock.ProcessWeightedAverage(operation);
                stock.ProcessQuantity(operation);
            }
            stock.Profit.Should().Be(50000.00M);
            stock.Loss.Should().Be(25000.00M);
            
        }
    }
}
