using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day5.Tests;

public class UnitTest1
{
    [Fact]
    public void CorrectlyParseVentLinesFromText()
    {
        var rawInput = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var expectedOutput = new List<VentLine>
        {
            new("0,9", "5,9"),
            new("8,0", "0,8"),
            new("9,4", "3,4")

        }.ToImmutableList();

        var output = FileHelper.ExtractVentLinesFromFile(rawInput);

        output.Should().BeEquivalentTo(expectedOutput);
    }

    [Fact]
    public void CorrectVerticalLineCoOrdsReturned()
    {
        var inputVentLine = new VentLine("1,1", "1,3");

        var expectedCoOrds = new List<CoOrd>
        {
            new(1,1),
            new(1,2),
            new(1,3)
        }.ToImmutableList();

        inputVentLine.LineCoOrds.Should().BeEquivalentTo(expectedCoOrds);
    }
    [Fact]
    public void CorrectHorizontalLineCoOrdsReturned()
    {
        var inputVentLine = new VentLine("1,1", "3,1");

        var expectedCoOrds = new List<CoOrd>
        {
            new(1,1),
            new(2,1),
            new(3,1)
        }.ToImmutableList();

        inputVentLine.LineCoOrds.Should().BeEquivalentTo(expectedCoOrds);
    }

    [Fact]
    public void CorrectDiagonalLinesCoOrdsReturned()
    {
        var inputVentLine = new VentLine("1,1", "3,3");

        var expectedCoOrds = new List<CoOrd>
        {
            new(1,1),
            new(2,2),
            new(3,3)
        }.ToImmutableList();

        inputVentLine.LineCoOrds.Should().BeEquivalentTo(expectedCoOrds);
    }
    
    [Fact]
    public void MapGridCanBeBuilt()
    {
        var inputVentLines = new List<VentLine>
        {
            new("0,9", "5,9"),
            new("8,8", "0,8"),
            new("9,4", "3,4"),
            new("1,1", "3,3")

        }.ToImmutableList();

        var exception = Record.Exception(() => new MapGrid(inputVentLines));
        
        Assert.Null(exception);
    }

    [Fact]
    public void MapGridWithNoDiagonalsReturnsRightPart1Value()
    {
        var rawInput = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var filteredInput = FileHelper
            .ExtractVentLinesFromFile(rawInput)
            .Where(line => !line.Diagonal)
            .ToImmutableList();

        var result = Calculators
            .Overlaps(new MapGrid(filteredInput))
            .Count(v => v.overlapCount >= 2);
        
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void MapGridWithDiagonalsReturnsRightPart2Value()
    {
        var rawInput = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var filteredInput = FileHelper
            .ExtractVentLinesFromFile(rawInput)
            .ToImmutableList();

        var result = Calculators
            .Overlaps(new MapGrid(filteredInput))
            .Count(v => v.overlapCount >= 2);
        
        Assert.Equal(12, result);
    }

    [Fact]
    public void FullInputAllLinesHaveLength()
    {
        var rawInput = FileHelper.ExtractInputFromFile("../../../../Day5/bin/Debug/net6.0/day5input.txt");

        var parsedInput = FileHelper.ExtractVentLinesFromFile(rawInput);

        var violations = parsedInput
            .Count(line => line.LineCoOrds.Count < 1);
        
        Assert.Equal(0, violations);
    }
    [Fact]
    public void FullInputAllComputedPositionsContainStartAndEnd()
    {
        var rawInput = FileHelper.ExtractInputFromFile("../../../../Day5/bin/Debug/net6.0/day5input.txt");

        var parsedInput = FileHelper
            .ExtractVentLinesFromFile(rawInput)
            .Where(l => !l.Diagonal)
            .ToImmutableList();

        var violations = parsedInput.Where(line => !FullVentLineCoOrdsContainStartOrEnd(line));
        
        Assert.Empty(violations);
    }

    private static bool FullVentLineCoOrdsContainStartOrEnd(VentLine ventLine)
    {
        return ventLine.LineCoOrds
            .Select(l => new { Start = ventLine.Start.CompoundCoordinate, End = ventLine.End.CompoundCoordinate, l.CompoundCoordinate })
            .Any(l => l.CompoundCoordinate == l.Start || l.CompoundCoordinate == l.End);
    }
}