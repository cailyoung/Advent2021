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
    public void MapGridCanNotBeBuiltFromMixed()
    {
        var inputVentLines = new List<VentLine>
        {
            new("0,9", "5,9"),
            new("8,0", "0,8"),
            new("9,4", "3,4")

        }.ToImmutableList();

        Assert.Throws<ArgumentException>(() => new MapGrid(inputVentLines));
    }
    
    [Fact]
    public void MapGridCanBeBuilt()
    {
        var inputVentLines = new List<VentLine>
        {
            new("0,9", "5,9"),
            new("8,8", "0,8"),
            new("9,4", "3,4")

        }.ToImmutableList();

        var exception = Record.Exception(() => new MapGrid(inputVentLines));
        
        Assert.Null(exception);
    }

    [Fact]
    public void MapGridReturnsRightPart1Value()
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
}