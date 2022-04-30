using System;
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
}