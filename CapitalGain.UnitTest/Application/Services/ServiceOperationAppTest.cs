using CapitalGain.Application.Service;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CapitalGain.UnitTest.Application.Services
{
    public class ServiceOperationAppTest
    {
        [Theory]
        /* Caso 1*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 100},"+
                    "{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50},"+
                    "{ \"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 50}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00}]")]
        /* Caso 2*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},"+
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 5000},"+
                    "{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000}]",
            "[{\"tax\":0.00},{\"tax\":10000.00},{\"tax\":0.00}]")]
        /* Caso 3*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000},"+
                    "{\"operation\":\"sell\", \"unit-cost\":5.00, \"quantity\": 5000},"+
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 3000}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":1000.00}]")]
        /* Caso 4*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}," +
                    "{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00}]")]
        /* Caso 5*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}," +
                    "{\"operation\":\"buy\", \"unit-cost\":25.00, \"quantity\": 5000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 10000},"+
                    "{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 5000}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":10000.00}]")]

        /* Caso 6*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":3000.00}]")]


        /* Caso 7*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":2.00, \"quantity\": 5000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":20.00, \"quantity\": 2000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":25.00, \"quantity\": 1000}," +
                    "{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":15.00, \"quantity\": 5000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 4350},"+
                    "{\"operation\":\"sell\", \"unit-cost\":30.00, \"quantity\": 650}]",
            "[{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":3000.00},{\"tax\":0.00},{\"tax\":0.00},{\"tax\":3700.00},{\"tax\":0.00}]")]

        /* Caso 8*/
        [InlineData("[{\"operation\":\"buy\", \"unit-cost\":10.00, \"quantity\": 10000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}," +
                    "{\"operation\":\"buy\", \"unit-cost\":20.00, \"quantity\": 10000}," +
                    "{\"operation\":\"sell\", \"unit-cost\":50.00, \"quantity\": 10000}]",
            "[{\"tax\":0.00},{\"tax\":80000.00},{\"tax\":0.00},{\"tax\":60000.00}]")]

        public void Process_capital_gain(string input, string expectedResult)
        {
            OperationService operationService = new OperationService(new Domain.Stocks.OperationService());
            var result = operationService.ProcessAsJson(input);
            result.Should().Be(expectedResult);
        }
    }
}
