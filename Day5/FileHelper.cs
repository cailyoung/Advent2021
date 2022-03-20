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
        return ImmutableList<VentLine>.Empty;
    }

}

public class VentLine
{
    public CoOrd Start { get; }
    public CoOrd End { get; }

    public VentLine(CoOrd start, CoOrd end)
    {
        Start = start;
        End = end;
    }

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

    public CoOrd(int xValue, int yValue)
    {
        XValue = xValue;
        YValue = yValue;
    }

    public CoOrd(string textCoOrd)
    {
        XValue = Convert.ToInt32(textCoOrd.Split(",").First());
        YValue = Convert.ToInt32(textCoOrd.Split(",").Reverse().First());
    }
}