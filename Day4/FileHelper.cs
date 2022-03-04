namespace Day4;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static IEnumerable<int> ExtractBingoNumbersFromFile(string[] input)
    {
        var firstLine = input[0];

        return firstLine.Split(',').Select(s => Convert.ToInt32(s));
    }
}