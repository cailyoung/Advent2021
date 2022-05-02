using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day10.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", "}")]
    [InlineData("[[<[([]))<([[{}[[()]]]", ")")]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", "]")]
    [InlineData("[<(<(<(<{}))><([]([]()", ")")]
    [InlineData("<{([([[(<>()){}]>(<<{{", ">")]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", "")]
    public void FirstCorruptTokenFinderIsAccurate(string input, string? expectedFailureToken)
    {
        var actualOutput = Parsing.FindFirstCorruptToken(input);

        actualOutput.Should().Be(expectedFailureToken);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
    [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
    public void LineCompleterWorksCorrectly(string incompleteLine, string expectedCompletion)
    {
        var actualOutput = Parsing.GenerateClosingSequence(incompleteLine);

        actualOutput.Should().Be(expectedCompletion);
    }

    [Fact]
    public void CorruptLineSelectorWorks()
    {
        var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".Split(Environment.NewLine);

        var expectedOutput = @"{([(<{}[<>[]}>{[]{[(<()>
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{".Split(Environment.NewLine);

        var actualOutput = Parsing.FindCorruptLines(input);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }
    
    [Fact]
    public void IncompleteLineSelectorWorks()
    {
        var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".Split(Environment.NewLine);

        var expectedOutput = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
(((({<>}<{<{<>}{[]{[]{}
{<[[]]>}<{[{[{[]{()[[[]
<{([{{}}[<[[[<>{}]]]>[]]".Split(Environment.NewLine);

        var actualOutput = Parsing.FindIncompleteLines(input);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }

    [Fact]
    public void ExampleGivesCorrectSyntaxErrorScore()
    {
        var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".Split(Environment.NewLine);

        var badTokens = 
            Parsing.FindCorruptLines(input)
            .Select(Parsing.FindFirstCorruptToken)
            .Select(char.Parse);

        var score = Scoring.CalculateSyntaxErrorScoreForTokens(badTokens);

        score.Should().Be(26397);
    }

    [Theory]
    [InlineData("}}]])})]", 288957)]
    [InlineData(")}>]})", 5566)]
    [InlineData("}}>}>))))", 1480781)]
    [InlineData("]]}}]}]}>", 995444)]
    [InlineData("])}>", 294)]
    public void CompletionStringScoringIsCorrect(string completionString, int expectedScore)
    {
        var score = Scoring.CalculateLineCompletionScoreForSingleLine(completionString);

        score.Should().Be(expectedScore);
    }

    [Fact]
    public void MiddleScoreFinderIsCorrect()
    {
        var input = @"}}]])})]
)}>]})
}}>}>))))
]]}}]}]}>
])}>".Split(Environment.NewLine);

        var actualScore = Scoring.FindMiddleScore(input);

        actualScore.Should().Be(288957);
    }
}