using FluentAssertions;

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
            new("CH", "B"),
            new("HH", "N"),
            new("CB", "H"),
            new("NH", "C"),
            new("HB", "C"),
            new("HC", "B"),
            new("HN", "C"),
            new("NN", "C"),
            new("BH", "H"),
            new("NC", "B"),
            new("NB", "B"),
            new("BN", "B"),
            new("BB", "N"),
            new("BC", "B"),
            new("CC", "N"),
            new("CN", "C")
        };

        var actualParsed = FileHelper.GetInsertionRules(input);

        actualParsed.Should().BeEquivalentTo(expectedInsertionRules);
    }
}