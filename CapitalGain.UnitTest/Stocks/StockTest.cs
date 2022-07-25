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
    }
}
