using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Day2.Tests;

public class UnitTest1
{
    [Fact]
    public void Part1SubmarinePositionIsCorrect()
    {
        var sub = new Submarine();
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 5));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Down, 5));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 8));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Up, 3));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Down, 8));
        sub.Part1Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 2));

        var product = sub.GetCurrentHorizontalPosition() * sub.GetCurrentDepth();
        
        Assert.Equal(150, product);
    }
    
    [Fact]
    public void Part2SubmarinePositionIsCorrect()
    {
        var sub = new Submarine();
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 5));
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Down, 5));
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 8));
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Up, 3));
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Down, 8));
        sub.Part2Move(Submarine.Command.BuildCommand(Submarine.Instruction.Forward, 2));

        var product = sub.GetCurrentHorizontalPosition() * sub.GetCurrentDepth();
        
        Assert.Equal(900, product);
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
                Instruction = Submarine.Instruction.Down,
                Distance = 5
            },
            new()
            {
                Instruction = Submarine.Instruction.Forward,
                Distance = 1
            },
            new()
            {
                Instruction = Submarine.Instruction.Up,
                Distance = 5
            }
        };

        expectedOutput.Should().BeEquivalentTo(FileHelper.ListCommandsFromFile(testInput));
    }
}