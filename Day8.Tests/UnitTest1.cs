using FluentAssertions;
using Xunit;

namespace Day8.Tests;

public class UnitTest1
{
    [Fact]
    public void ParserSplitsSingleLineCorrectly()
    {
        var inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";

        var expectedSplit = new string[]
        {
            "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab",
            "cdfeb fcadb cdfeb cdbaf"
        };

        var actualSplit = FileHelper.SplitInputLine(inputLine);

        actualSplit.Should().BeEquivalentTo(expectedSplit);
    }
}