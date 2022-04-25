using System;
using System.Collections.Generic;
using System.Linq;
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

    [Fact]
    public void ExampleInputGivesCorrectRiskScore()
    {
        var exampleMap = FileHelper.GenerateInitialHeightMap(@"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine));

        var actualRiskScore = MapOperations.GetMapRisk(exampleMap);

        actualRiskScore.Should().Be(15);
    }

    [Fact]
    public void ExampleInputGivesCorrectBasins()
    {
        var exampleMap = FileHelper.GenerateInitialHeightMap(@"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine));

        var actualBasins = MapOperations.FindAllBasins(exampleMap);

        var product = actualBasins
            .Select(b => b.Size)
            .Aggregate((r, i) => r * i);

        product.Should().Be(1134);
    }

    [Theory]
    [InlineData(1,0,1,3)]
    [InlineData(9,0,0,9)]
    [InlineData(2,2,5,14)]
    [InlineData(6,4,5,9)]
    public void BasinFinderIsCorrect(short xValue, short yValue, short height, int expectedSize)
    {
        var startingPosition = new Position(xValue, yValue, height, true);
        
        var exampleMap = FileHelper.GenerateInitialHeightMap(@"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine));

        var actualBasinSize = MapOperations.FindAllPositionsInBasin(startingPosition, exampleMap).Length;

        actualBasinSize.Should().Be(expectedSize);
    }
}