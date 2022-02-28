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
        var response = new List<BitArray>();
        
        foreach (var row in input)
        {
            var foo = row.Select(s => s.ToString()).ToArray();

            var fooAsInts = foo.Select(s => Convert.ToInt32(s)).ToArray();

            var bitArray = new BitArray(fooAsInts.Select(Convert.ToBoolean).ToArray());
            
            response.Add(bitArray);
        }

        return response;
    }
}