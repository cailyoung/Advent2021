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

    [Fact]
    public void ExampleFirstFoldHasCorrectDotCount()
    {
        var input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0".Split(Environment.NewLine);

        var inputDots = FileHelper.GetDots(input);
        var inputPaper = new TransparentPaper(inputDots);

        var foldedPaper = inputPaper.Fold(7, Axis.Y);

        foldedPaper.DotCount.Should().Be(17);
    }
}