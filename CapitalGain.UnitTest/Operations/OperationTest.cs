using CapitalGain.Domain.Operations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CapitalGain.UnitTest.Operations
{
    public class OperationTest
    {
        [Theory]
        [InlineData(1000,55.00,55000.00)]
        public void Calc_total_when_process_operation(int quantity, decimal unitCost, decimal expectedTotal)
        {
            var operation = new Operation();
            operation.Quantity = quantity;
            operation.UnitCost = unitCost;
            operation.Process();
            operation.Total.Should().Be(expectedTotal);

        }
    }
}
