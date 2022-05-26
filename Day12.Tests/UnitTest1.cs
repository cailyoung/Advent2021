using FluentAssertions;

namespace Day12.Tests;

public class UnitTest1
{
    [Fact]
    public void SmallExampleHasTenPaths()
    {
        var input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end".Split(Environment.NewLine);

        var actualCaveSystem = FileHelper.ParseInput(input);

        var actualPaths = actualCaveSystem.ValidPaths;

        actualPaths.Should().Be(10);
    }
}