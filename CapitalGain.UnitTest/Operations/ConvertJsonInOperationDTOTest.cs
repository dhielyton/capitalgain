using CapitalGain.Application.Helper;
using CapitalGain.Application.Model;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CapitalGain.UnitTest.Operations
{
    public class ConvertJsonInOperationDTOTest
    {


        [Theory]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00,\"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":20.00,\"quantity\": 5000}]",2)]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":20.00,\"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":10.00,\"quantity\": 5000}]",2)]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50},{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}]",3)]
        public void Convert_input_json_in_orders_with_sucess(string input, int expectAmount)
        {
            var operations = input.Convert();
            operations.Should().NotBeNull();
            operations.Count.Should().Be(expectAmount);
        }

        [Theory]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00,\"quantity\": 10000}]",
            "buy",10.00,10000)]
        public void Validate_conversion_json_in_operator(string input, string expectedOperationType, decimal expectedUnitCost, int expectedQuantity )
        {
            var operation = input.Convert().First();
            operation.OperationType.Should().Be(expectedOperationType);
            operation.UnitCost.Should().Be(expectedUnitCost);
            operation.Quantity.Should().Be(expectedQuantity);
        }

       
        
    }

    
}
