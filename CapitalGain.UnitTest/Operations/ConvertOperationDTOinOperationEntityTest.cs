﻿using CapitalGain.Application.Model;
using CapitalGain.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CapitalGain.Application.Helper;
using FluentAssertions;

namespace CapitalGain.UnitTest.Operations
{
    public class ConvertOperationDTOinOperationEntityTest
    {
        [Theory]
        [InlineData("buy",50.00, 1000, OperationType.BUY)]
        [InlineData("sell", 50.00, 1000, OperationType.SELL)]
        public void Convert_operation_dto_buy_in_operation_entity(string operatonType, decimal unitCost, int quantity, OperationType expectedOperationType)
        {
            var operationDto = new OperationDTO { OperationType = operatonType, UnitCost = unitCost, Quantity = quantity };
            var operation = operationDto.Convert();
            operation.OperationType.Should().Be(expectedOperationType);
            operation.UnitCost.Should().Be(unitCost);
            operation.Quantity.Should().Be(quantity);

        }
    }
}
