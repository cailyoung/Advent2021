namespace Day7;

public class FileHelper
{
    public static IEnumerable<int> ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput.SelectMany(s => s.Split(",")).Select(n => Convert.ToInt32(n));
    }

    public static string[] SplitInputLine(string inputLine)
    {
        return new string[2];
    }
}