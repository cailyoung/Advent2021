namespace Day11;

public static class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static EnergyMap GenerateInitialEnergyMap(string[] input)
    {
        return new EnergyMap(input
            .Select(row => row.Select(s => Convert.ToInt32(s.ToString())))
            .SelectMany((r, index) => GeneratePositionRow(r, Convert.ToInt32(index))));
    }

    private static IEnumerable<Position> GeneratePositionRow(IEnumerable<int> values, int rowNumber)
    {
        var valueArray = values.ToArray();

        return Enumerable
            .Range(0, valueArray.Length)
            .Select((_, i) => new Position(Convert.ToInt32(i), rowNumber, valueArray[i]));
    }
}