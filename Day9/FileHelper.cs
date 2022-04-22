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
            .Select(row => row.Select(s => Convert.ToInt32(s.ToString())))
            .SelectMany(GeneratePositionRow));
    }

    private static IEnumerable<Position> GeneratePositionRow(IEnumerable<int> values, int rowNumber)
    {
        var valueArray = values.ToArray();

        return Enumerable
            .Range(0, valueArray.Length)
            .Select((_, i) => new Position(i, rowNumber, valueArray[i]));
    }
}