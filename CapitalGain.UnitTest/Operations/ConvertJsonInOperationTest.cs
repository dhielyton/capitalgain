using CapitalGain.Application.Helper;
using CapitalGain.Application.Model;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace CapitalGain.UnitTest.Operations
{
    public class ConvertJsonInOperationTest
    {


        [Theory]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00,\"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":20.00,\"quantity\": 5000}]")]
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":20.00,\"quantity\": 10000},{\"operation\":\"sell\", \"unit-cost\":10.00,\"quantity\": 5000}]")]
        public void Convert_input_json_in_orders_with_sucess(string input)
        {
            var operations = input.Convert();
            operations.Should().NotBeNull();
            operations.Count.Should().Be(2);
        }


        public void Convert_input_json_in_order_with_exception()
        {

        }
        
    }

    
}
