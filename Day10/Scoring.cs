namespace Day10;

public static class Scoring
{
    private static Dictionary<char, int> TokenScores = new()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 }
    };

    public static int CalculateScoreForTokens(IEnumerable<char> tokens)
    {
        return int.MinValue;
    }
}