namespace Day8;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }
    
    public static DataRow SplitInputLine(string inputLine)
    {
        var split = inputLine.Split("|", StringSplitOptions.TrimEntries);

        return new DataRow(split[0], split[1]);
    }

    public static IEnumerable<Digit> SplitDataRowSection(string input)
    {
        return input.Split(" ").Select(i => new Digit(i));
    }
}