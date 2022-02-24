using Xunit;

namespace Day2.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var sub = new Submarine();
        sub.Move(Submarine.Instruction.Forward, 5);
        sub.Move(Submarine.Instruction.Down, 5);
        sub.Move(Submarine.Instruction.Forward, 8);
        sub.Move(Submarine.Instruction.Up, 3);
        sub.Move(Submarine.Instruction.Down, 8);
        sub.Move(Submarine.Instruction.Forward, 2);

        var product = sub.GetCurrentHorizontalPosition() * sub.GetCurrentDepth();
        
        Assert.Equal(150, product);
    }
}