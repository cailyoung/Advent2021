using System;
using FluentAssertions;
using Xunit;

namespace Day9.Tests;

public class UnitTest1
{
    [Fact]
    public void TwoLineInputGeneratesValidMap()
    {
        var input = @"12
23"
            .Split(Environment.NewLine);

        var expectedOutput = new HeightMap(new[]
        {
            new Position(0,0,1),
            new Position(0,1,2),
            new Position(1,0,2),
            new Position(1,1,3)
        });

        var actualOutput = FileHelper.GenerateInitialHeightMap(input);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }
}