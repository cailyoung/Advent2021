using System;
using FluentAssertions;
using Xunit;

namespace Day11.Tests;

public class UnitTest1
{
    [Fact]
    public void SmallExampleFirstDayWorksCorrectly()
    {
        var input = @"11111
19991
19191
19991
11111".Split(Environment.NewLine);

        var initialMap = FileHelper.GenerateInitialEnergyMap(input);

        var expected = @"34543
40004
50005
40004
34543".Split(Environment.NewLine);

        var expectedMap = FileHelper.GenerateInitialEnergyMap(expected);

        var actualMap = MapOperations.ProduceNextStep(initialMap);

        actualMap.Should().BeEquivalentTo(expectedMap);
    }
}