namespace Day2;

public class Submarine
{
    public class Command
    {
        public Instruction Instruction { get; set; }
        public int Distance { get; set; }

        public static Command BuildCommand(Instruction instruction, int distance)
        {
            return new Command()
            {
                Instruction = instruction,
                Distance = distance
            };
        }
    }
    
    public enum Instruction {
        Forward,
        Down,
        Up
    }

    private int HorizontalPosition;
    private int Depth;
    private int Aim;

    public void Part1TakeCommands(Command[] commands)
    {
        foreach (var command in commands)
        {
            Part1Move(command);
        }
    }
    
    public void Part2TakeCommands(Command[] commands)
    {
        foreach (var command in commands)
        {
            Part2Move(command);
        }
    }
    
    public void Part1Move(Command command)
    {
        switch (command.Instruction)
        {
            case Instruction.Forward:
                HorizontalPosition += command.Distance;
                break;
            case Instruction.Down:
                Depth += command.Distance;
                break;
            case Instruction.Up:
                Depth -= command.Distance;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command.Instruction), command.Instruction, "Unknown command supplied");
        }
    }

    public void Part2Move(Command command)
    {
        switch (command.Instruction)
        {
            case Instruction.Forward:
                HorizontalPosition += command.Distance;
                Depth += (Aim * command.Distance);
                break;
            case Instruction.Down:
                Aim += command.Distance;
                break;
            case Instruction.Up:
                Aim -= command.Distance;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(command.Instruction), command.Instruction, "Unknown command supplied");
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