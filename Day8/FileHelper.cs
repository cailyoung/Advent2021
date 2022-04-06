namespace Day8;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }
    
    public static IEnumerable<string> SplitInputLine(string inputLine)
    {
        return inputLine.Split("|", StringSplitOptions.TrimEntries);
    }
}