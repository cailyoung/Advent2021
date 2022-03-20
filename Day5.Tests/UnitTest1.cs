using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public void CorrectLineCoOrdsReturned()
    {
        var inputVentLine = new VentLine("1,1", "1,3");

        var expectedCoOrds = new List<CoOrd>
        {
            new("1,1"),
            new("1,2"),
            new("1,3")
        }.ToImmutableList();

        inputVentLine.LineCoOrds.Should().BeEquivalentTo(expectedCoOrds);
    }
}