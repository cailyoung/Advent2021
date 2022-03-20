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