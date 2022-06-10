using FluentAssertions;

namespace Day13.Tests;

public class UnitTest1
{
    [Fact]
    public void ParserCanGenerateDots()
    {
        var input = @"6,10
0,14
9,10".Split(Environment.NewLine);

        var expectedDots = new List<Dot>
        {
            new(6, 10),
            new(0, 14),
            new(9, 10)
        };

        var actualDots = FileHelper.GetDots(input);

        actualDots.Should().BeEquivalentTo(expectedDots);
    }
}