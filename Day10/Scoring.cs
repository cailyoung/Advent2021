namespace Day10;

public static class Scoring
{
    private static readonly Dictionary<char, int> InvalidTokenSyntaxErrorScores = new()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 }
    };

    public static int CalculateSyntaxErrorScoreForTokens(IEnumerable<char> tokens)
    {
        return tokens.Select(c => InvalidTokenSyntaxErrorScores[c]).Sum();
    }
}