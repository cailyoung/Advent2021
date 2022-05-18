using System;
using System.Collections.Generic;
using System.Linq;
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

        actualMap.EnergyMap.Map.Should().BeEquivalentTo(expectedMap.Map);
    }

    [Fact]
    public void SmallExampleSecondDayWorksCorrectly()
    {
        var input = @"11111
19991
19191
19991
11111".Split(Environment.NewLine);

        var initialMap = FileHelper.GenerateInitialEnergyMap(input);
        
        var expected = @"45654
51115
61116
51115
45654".Split(Environment.NewLine);

        var expectedMap = FileHelper.GenerateInitialEnergyMap(expected);

        var actualMaps = MapOperations.ProduceFutureStepState(initialMap, 2);

        actualMaps.Last().EnergyMap.Map.Should().BeEquivalentTo(expectedMap.Map);
    }

    [Theory]
    [InlineData(10, 204)]
    [InlineData(100, 1656)]
    public void LargeExampleFutureDaysWorkCorrectly(int stepsToRun, int expectedFlashCount)
    {
        var input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526".Split(Environment.NewLine);

        var initialMap = FileHelper.GenerateInitialEnergyMap(input);

        var actualMaps = MapOperations.ProduceFutureStepState(initialMap, stepsToRun);

        actualMaps.Sum(p => p.FlashCount).Should().Be(expectedFlashCount);
    }

    [Fact]
    public void ExampleInputProducesCorrectAllFlashingStep()
    {
        var input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526".Split(Environment.NewLine);

        var initialMap = FileHelper.GenerateInitialEnergyMap(input);

        var actualCalc = MapOperations.CalculateStepWhenAllFlash(initialMap);

        actualCalc.Should().Be(195);
    }
}