using System.Collections;
using System.Globalization;

namespace Day3;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static IEnumerable<BitArray> ParseInput(string[] input)
    {
        return input
            .Select(ConvertBinaryCharsToBoolArray())
            .Select(bools => new BitArray(bools));
    }

    private static Func<string, bool[]> ConvertBinaryCharsToBoolArray()
    {
        return s => s
            .Select(c => c.ToString())
            .Select(character => Convert.ToInt32(character))
            .Select(Convert.ToBoolean)
            .ToArray();
    }
}