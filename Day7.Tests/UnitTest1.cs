using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day7.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 41)]
    [InlineData(3, 39)]
    [InlineData(10, 71)]
    [InlineData(2, 37)]
    public void TargetPositionGetsCorrectFuelUsage(int targetPosition, int expectedFuelConsumed)
    {
        var inputData = "16,1,2,0,4,2,7,1,2,14"
            .Split(",")
            .Select(v => Convert.ToInt32(v));

        var inputSubField = new SubmarineField(inputData);
        
        var actualUsage = inputSubField
            .GetFuelConsumptionValues()
            .Where(v => v.TargetPosition == targetPosition)
            .Select(v => v.FuelConsumed)
            .Single();

        actualUsage.Should().Be(expectedFuelConsumed);
    }
}