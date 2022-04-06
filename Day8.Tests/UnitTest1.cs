using System.Runtime.InteropServices;
using FluentAssertions;
using Xunit;

namespace Day8.Tests;

public class UnitTest1
{
    [Fact]
    public void ParserSplitsSingleLineCorrectly()
    {
        const string inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";

        var expectedSplit = new[]
        {
            "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab",
            "cdfeb fcadb cdfeb cdbaf"
        };

        var actualSplit = FileHelper.SplitInputLine(inputLine);

        actualSplit.Should().BeEquivalentTo(expectedSplit);
    }

    [Theory]
    [InlineData("gc", Digit.Character.One)]
    [InlineData("cbg", Digit.Character.Seven)]
    [InlineData("gecf", Digit.Character.Four)]
    [InlineData("dgebacf", Digit.Character.Eight)]
    public void DigitCharacterReturnsCorrect(string inputDigit, Digit.Character expectedCharacter)
    {
        var actualDigit = new Digit(inputDigit);

        actualDigit.CurrentCharacter.Should().Be(expectedCharacter);
    }
    
}