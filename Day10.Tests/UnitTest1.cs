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
}