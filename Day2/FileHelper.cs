namespace Day2;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static Submarine.Command[] ListCommandsFromFile(string[] inputCommands)
    {
        var commands = inputCommands
            .Select(s => s.Split(" "))
            .Select(s => new Submarine.Command()
        {
            Instruction = Enum.Parse<Submarine.Instruction>(s[0]),
            Distance = int.Parse(s[1])
        }).ToArray();
        
        return commands;
    }
}