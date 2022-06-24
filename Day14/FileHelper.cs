namespace Day14;

public static class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static string GetTemplate(string[] input)
    {
        return input.First();
    }

    public static IEnumerable<PairInsertionRule> GetInsertionRules(string[] input)
    {
        return input
            .Skip(2)
            .Select(r => r.Split(" -> "))
            .Select(r => new PairInsertionRule(r.First(), char.Parse(r.Last())));
    }
}