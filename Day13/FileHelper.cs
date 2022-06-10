namespace Day13;

public static class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static IEnumerable<Dot> GetDots(string[] input)
    {
        return input
            .Select(row => row.Split(','))
            .Select(splitRow => new Dot(int.Parse(splitRow.First()), int.Parse(splitRow.Last())));
    }

    public static IEnumerable<(int CoOrdToFoldAt, Axis axis)> GetFolds(string[] input)
    {
        return new List<(int CoOrdToFoldAt, Axis axis)>();
    } 
}