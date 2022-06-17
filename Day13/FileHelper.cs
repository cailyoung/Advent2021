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

    public static IEnumerable<FoldInstruction> GetFolds(string[] input)
    {
        var folds = input
            .Select(row => row.Replace("fold along ", string.Empty))
            .Select(row => row.Split('='))
            .Select(row => (int.Parse(row.Last()), Enum.Parse<Axis>(row.First().ToUpperInvariant())))
            .Select(tuple => new FoldInstruction(tuple.Item1, tuple.Item2));

        return folds;
    } 
}