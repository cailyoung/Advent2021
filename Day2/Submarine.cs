namespace Day2;

public class Submarine
{
    public enum Instruction {
        Forward,
        Down,
        Up
    }

    private int HorizontalPosition = 0;
    private int Depth = 0;

    public void Move(Instruction instruction, int distance)
    {
        switch (instruction)
        {
            case Instruction.Forward:
                HorizontalPosition += distance;
                break;
            case Instruction.Down:
                Depth += distance;
                break;
            case Instruction.Up:
                Depth -= distance;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null);
        }
    }

    public int GetCurrentHorizontalPosition()
    {
        return HorizontalPosition;
    }

    public int GetCurrentDepth()
    {
        return Depth;
    }
}