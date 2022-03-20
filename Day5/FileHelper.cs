using System.Collections.Immutable;

namespace Day5;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static ImmutableList<VentLine> ExtractVentLinesFromFile(string[] input)
    {
        var workingList = input
            .Select(row => row.Split(" -> "))
            .Select(coOrdPair => new VentLine(coOrdPair[0], coOrdPair[1]))
            .ToImmutableList();

        return workingList;
    }

}

public class VentLine
{
    public CoOrd Start { get; }
    public CoOrd End { get; }

    public VentLine(string textCoOrdStart, string textCoOrdEnd)
    {
        Start = new CoOrd(textCoOrdStart);
        End = new CoOrd(textCoOrdEnd);
    }
}

public class CoOrd
{
    public int XValue { get; }
    public int YValue { get; }

    public CoOrd(string textCoOrd)
    {
        XValue = Convert.ToInt32(textCoOrd.Split(",").First());
        YValue = Convert.ToInt32(textCoOrd.Split(",").Reverse().First());
    }
}