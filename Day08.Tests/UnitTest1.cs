using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day8.Tests;

public class UnitTest1
{
    [Fact]
    public void ParserSplitsSingleLineCorrectly()
    {
        const string inputLine = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";

        var expectedSplit = new DataRow("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab",
            "cdfeb fcadb cdfeb cdbaf");

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

    [Fact]
    public void DigitCreationFromStringIsCorrect()
    {
        var inputValues = "gc cbg gecf dgebacf";

        var expectedDigits = new List<Digit>
        {
            new(Digit.Character.One, "gc"),
            new(Digit.Character.Seven, "cbg"),
            new(Digit.Character.Four, "gecf"),
            new(Digit.Character.Eight, "dgebacf")
        };

        var actualDigits = new DataRow(inputValues, String.Empty).GetInputDigits();

        actualDigits.Should().BeEquivalentTo(expectedDigits);
    }

    [Fact]
    public void ExampleInputGeneratesRightPartOneValue()
    {
        var exampleInput = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce".Split(Environment.NewLine);

        var outputsOnly = exampleInput
            .Select(FileHelper.SplitInputLine);

        var outputDigits = outputsOnly.SelectMany(dr => dr.GetOutputDigits());

        var actualCount = DigitAnalyser.CalculateNumberOfUniqueSegmentCountDigits(outputDigits);

        actualCount.Should().Be(26);
    }

    [Fact]
    public void CharacterInferenceIsCorrect()
    {
        var exampleInput = new List<Digit>
        {
            new("acedgfb"),
            new("cdfbe"),
            new("gcdfa"),
            new("fbcad"),
            new("dab"),
            new("cefabd"),
            new("cdfgeb"),
            new("eafb"),
            new("cagedb"),
            new("ab")
        };

        var expectedOutput = new Dictionary<Digit.Character, char[]>
        {
            { Digit.Character.Eight, "acedgfb".ToArray() },
            { Digit.Character.Five, "cdfbe".ToArray() },
            { Digit.Character.Two, "gcdfa".ToArray() },
            { Digit.Character.Three, "fbcad".ToArray() },
            { Digit.Character.Seven, "dab".ToArray() },
            { Digit.Character.Nine, "cefabd".ToArray() },
            { Digit.Character.Six, "cdfgeb".ToArray() },
            { Digit.Character.Four, "eafb".ToArray() },
            { Digit.Character.Zero, "cagedb".ToArray() },
            { Digit.Character.One, "ab".ToArray() }
        };

        var actualOutput = DigitAnalyser.GenerateCharacterMappings(exampleInput);

        actualOutput.Should().BeEquivalentTo(expectedOutput);
    }

    [Theory]
    [InlineData("cdfeb", Digit.Character.Five)]
    [InlineData("fcadb", Digit.Character.Three)]
    [InlineData("cdbaf", Digit.Character.Three)]
    public void GivenCharacterInferenceNewDigitIsCorrect(string newInput, Digit.Character expectedCharacter)
    {
        var exampleInput = new List<Digit>
        {
            new("acedgfb"),
            new("cdfbe"),
            new("gcdfa"),
            new("fbcad"),
            new("dab"),
            new("cefabd"),
            new("cdfgeb"),
            new("eafb"),
            new("cagedb"),
            new("ab")
        };

        var characterInferenceMap = DigitAnalyser.GenerateCharacterMappings(exampleInput);

        var newCharacterInference = DigitAnalyser.IdentifyCharacter(newInput, characterInferenceMap);

        newCharacterInference.Should().Be(expectedCharacter);
    }

    [Fact]
    public void OutputRowCanBeConvertedIntoNumber()
    {
        var exampleOutput = new List<Digit>
        {
            new(Digit.Character.Five, "cdfeb"),
            new(Digit.Character.Three, "fcadb"),
            new(Digit.Character.Five, "cdfeb"),
            new(Digit.Character.Three, "cdfab")
        };

        var actualOutputValue = DataRow.GenerateOutputSectionNumber(exampleOutput);

        actualOutputValue.Should().Be(5353);
    }    
    [Fact]
    public void ExampleInputGeneratesRightPartTwoValue()
    {
        var exampleInput = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce".Split(Environment.NewLine);

        var dataRows = exampleInput
            .Select(FileHelper.SplitInputLine)
            .ToList();
        
        var actualCount = DataRow.GenerateMappedDataRows(dataRows)
            .Select(dr => dr.GetOutputDigits())
            .Select(DataRow.GenerateOutputSectionNumber)
            .Sum();

        actualCount.Should().Be(61229);
    }
}