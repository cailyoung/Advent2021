using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Day3.Tests;

public class UnitTest1
{
    [Fact]
    public void ParserReturnsValidOutput()
    {
        var testInput = @"
00100
11110
10110
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var expectedOutput = new List<BitArray>
        {
            new(new[] {false, false, true, false, false}),
            new(new[] {true, true, true, true, false}),
            new(new[] {true, false, true, true, false})
            };
        
        var output = FileHelper.ParseInput(testInput);

        output.Should().BeEquivalentTo(expectedOutput);
    }
}