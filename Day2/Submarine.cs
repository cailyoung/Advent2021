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
        forward,
        down,
        up
    }

    private int HorizontalPosition = 0;
    private int Depth = 0;

    public void Part1TakeCommands(Command[] commands)
    {
        foreach (var command in commands)
        {
            Part1Move(command);
        }
    }
    
    public void Part1Move(Command command)
    {
        switch (command.Instruction)
        {
            case Instruction.forward:
                HorizontalPosition += command.Distance;
                break;
            case Instruction.down:
                Depth += command.Distance;
                break;
            case Instruction.up:
                Depth -= command.Distance;
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