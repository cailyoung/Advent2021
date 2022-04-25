using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Day9.Tests;

public class UnitTest1
{
    [Fact]
    public void TwoLineInputGeneratesValidMap()
    {
        var input = @"21
23"
            .Split(Environment.NewLine);

        var expectedOutput = new HeightMap(new[]
        {
            new Position(0,0,2),
            new Position(1,0,1),
            new Position(0,1,2),
            new Position(1,1,3)
        });

        var actualOutput = FileHelper.GenerateInitialHeightMap(input);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }

    [Fact]
    public void ExampleMapGivesCorrectLowPoints()
    {
        var exampleMap = FileHelper.GenerateInitialHeightMap(@"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine));

        var expectedLowestPoints = new List<Position>
        {
            new(9, 0, 0, true),
            new(1, 0, 1, true),
            new(2, 2, 5, true),
            new(6, 4, 5, true)
        };

        var actualLowestPoints = MapOperations.GetLowestPositions(exampleMap);

        actualLowestPoints.Should().BeEquivalentTo(expectedLowestPoints);
    }
}