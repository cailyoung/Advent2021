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
}