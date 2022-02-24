using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day2.Tests;

public class UnitTest1
{
    [Fact]
    public void SubmarinePositionIsCorrect()
    {
        var sub = new Submarine();
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.forward, 5));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.down, 5));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.forward, 8));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.up, 3));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.down, 8));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.forward, 2));

        var product = sub.GetCurrentHorizontalPosition() * sub.GetCurrentDepth();
        
        Assert.Equal(150, product);
    }

    [Fact]
    public void FileInterpretationIsCorrect()
    {
        var testInput = @"
down 5
forward 1
up 5
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();
        
        var expectedOutput = new Submarine.Command[]
        {
            new()
            {
                Instruction = Submarine.Instruction.down,
                Distance = 5
            },
            new()
            {
                Instruction = Submarine.Instruction.forward,
                Distance = 1
            },
            new()
            {
                Instruction = Submarine.Instruction.up,
                Distance = 5
            }
        };

        expectedOutput.Should().BeEquivalentTo(FileHelper.ListCommandsFromFile(testInput));
    }
}