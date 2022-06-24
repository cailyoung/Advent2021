using FluentAssertions;
using FluentAssertions.Execution;

namespace Day14.Tests;

public class UnitTest1
{
    [Fact]
    public void InputParserGeneratesCorrectPolymerTemplate()
    {
        var input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split(Environment.NewLine);

        var actualParsed = FileHelper.GetTemplate(input);

        actualParsed.Should().Be("NNCB");
    }

    [Fact]
    public void InputParserGeneratesCorrectInsertionRules()
    {
        var input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split(Environment.NewLine);

        var expectedInsertionRules = new List<PairInsertionRule>
        {
            new("CH", 'B'),
            new("HH", 'N'),
            new("CB", 'H'),
            new("NH", 'C'),
            new("HB", 'C'),
            new("HC", 'B'),
            new("HN", 'C'),
            new("NN", 'C'),
            new("BH", 'H'),
            new("NC", 'B'),
            new("NB", 'B'),
            new("BN", 'B'),
            new("BB", 'N'),
            new("BC", 'B'),
            new("CC", 'N'),
            new("CN", 'C')
        };

        var actualParsed = FileHelper.GetInsertionRules(input);

        actualParsed.Should().BeEquivalentTo(expectedInsertionRules);
    }

    [Theory]
    [InlineData(1, "NCNBCHB")]
    [InlineData(2, "NBCCNBBBCBHCB")]
    [InlineData(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    [InlineData(4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
    public void EachInsertionRoundIsCorrect(int roundsToCalculate, string expectedChain)
    {
        var input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split(Environment.NewLine);

        var inputTemplate = FileHelper.GetTemplate(input);
        var inputRules = FileHelper.GetInsertionRules(input).ToArray();

        var workingChain = new PolymerChain(inputTemplate);

        for (int i = 0; i < roundsToCalculate; i++)
        {
            workingChain = workingChain.ApplyInsertionRules(inputRules);
        }

        workingChain.ChainString.Should().Be(expectedChain);
    }

    [Theory]
    [InlineData(5, 97)]
    [InlineData(10, 3073)]
    public void InsertionRoundLengthsAreCorrect(int roundsToCalculate, int expectedLength)
    {
        var input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split(Environment.NewLine);

        var inputTemplate = FileHelper.GetTemplate(input);
        var inputRules = FileHelper.GetInsertionRules(input).ToArray();

        var workingChain = new PolymerChain(inputTemplate);

        for (int i = 0; i < roundsToCalculate; i++)
        {
            workingChain = workingChain.ApplyInsertionRules(inputRules);
        }

        workingChain.ChainLength.Should().Be(expectedLength);
    }

    [Theory]
    [InlineData(10, 1749, 161)]
    [InlineData(40, 2192039569602, 3849876073)]
    public void StepTenGroupCountsAreCorrect(int roundsToCalculate, long expectedMost, long expectedLeast)
    {
        {
            var input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C".Split(Environment.NewLine);

            var inputTemplate = FileHelper.GetTemplate(input);
            var inputRules = FileHelper.GetInsertionRules(input).ToArray();

            var workingChain = new PolymerChain(inputTemplate);

            for (int i = 0; i < roundsToCalculate; i++)
            {
                workingChain = workingChain.ApplyInsertionRules(inputRules);
            }

            using (new AssertionScope())
            {
                workingChain.MostCommonElementCount.Should().Be(expectedMost);
                workingChain.LeastCommonElementCount.Should().Be(expectedLeast);
            }
        }
    }
}