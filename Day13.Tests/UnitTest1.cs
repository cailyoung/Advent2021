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
    public void ParserCanGenerateFoldInstructions()
    {
        var input = @"fold along y=7
fold along x=5".Split(Environment.NewLine);

        var expectedFolds = new List<FoldInstruction>
        {
            new(7, Axis.Y),
            new(5, Axis.X)
        };

        var actualFolds = FileHelper.GetFolds(input);

        actualFolds.Should().BeEquivalentTo(expectedFolds);
    }

    [Fact]
    public void ExampleFirstFoldProducesCorrectDotField()
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

        var expectedDotField = new List<Dot>
        {
            new(0, 0),
            new(2, 0),
            new(3, 0),
            new(6, 0),
            new(9, 0),
            new(0,1),
            new(4,1),
            new(6,2),
            new(10,2),
            new(0,3),
            new(4,3),
            new(1,4),
            new(3,4),
            new(6,4),
            new(8,4),
            new(9,4),
            new(10,4)
        };

        foldedPaper.MarkedDots.Should().OnlyContain(d => expectedDotField.Contains(d));
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

    [Fact]
    public void TwoFoldsProducesCorrectTextOutput()
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

        var foldInstructions = new List<FoldInstruction>
        {
            new(7, Axis.Y),
            new(5, Axis.X)
        };

        var actualFolded = inputPaper.FoldMultiple(foldInstructions);
        
        var expectedText = @"#####
#...#
#...#
#...#
#####
";

        actualFolded.ToString().Should().Be(expectedText);

    }
}