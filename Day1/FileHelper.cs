namespace Advent2021;

public class FileHelper
{
    public static int[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput
        .Select(int.Parse)
        .ToArray();
    }
}