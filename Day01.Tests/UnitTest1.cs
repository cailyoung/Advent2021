using System;
using System.Linq;
using Xunit;
using Advent2021;

namespace Day1.Tests;

public class UnitTest1
{
    [Fact]
    public void ExampleReturnsCorrectOutput()
    {
        var exampleInput = @"
199
200
208
210
200
207
240
269
260
263
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Assert.Equal(7, Calculators.CountMeasurementIncreases(exampleInput));
    }

    [Fact]
    public void WindowedSumsCalculateCorrectly()
    {
        var exampleInput = @"
199
200
208
210
200
207
240
269
260
263
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var expectedOutput = @"
607
618
618
617
647
716
769
792
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Assert.Equal(expectedOutput, Calculators.ProduceWindowedSums(exampleInput, 3));
    }
}