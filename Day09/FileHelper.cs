namespace Day9;

public static class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static HeightMap GenerateInitialHeightMap(string[] input)
    {
        return new HeightMap(input
            .Select(row => row.Select(s => Convert.ToInt16(s.ToString())))
            .SelectMany((r, index) => GeneratePositionRow(r, Convert.ToInt16(index))));
    }

    private static IEnumerable<Position> GeneratePositionRow(IEnumerable<short> values, short rowNumber)
    {
        var valueArray = values.ToArray();

        return Enumerable
            .Range(0, valueArray.Length)
            .Select((_, i) => new Position(Convert.ToInt16(i), rowNumber, valueArray[i]));
    }
}