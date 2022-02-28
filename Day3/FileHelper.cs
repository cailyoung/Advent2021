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
            .Select(row => row.Select(c => c.ToString())
                .Select(s => Convert.ToInt32(s))
                .Select(Convert.ToBoolean)
                .ToArray()
            )
            .Select(bools => new BitArray(bools));
    }
}