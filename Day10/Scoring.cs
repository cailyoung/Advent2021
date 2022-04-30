namespace Day10;

public static class Scoring
{
    private static readonly Dictionary<char, int> TokenScores = new()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 }
    };

    public static int CalculateScoreForTokens(IEnumerable<char> tokens)
    {
        return tokens.Select(c => TokenScores[c]).Sum();
    }
}