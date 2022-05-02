using MathNet.Numerics.Statistics;

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

    private static readonly Dictionary<char, int> CompletionTokenScore = new()
    {
        { ')', 1 },
        { ']', 2 },
        { '}', 3 },
        { '>', 4 }
    };

    public static int CalculateSyntaxErrorScoreForTokens(IEnumerable<char> tokens)
    {
        return tokens.Select(c => InvalidTokenSyntaxErrorScores[c]).Sum();
    }

    public static long CalculateLineCompletionScoreForSingleLine(string completionSequence)
    {
        var score = completionSequence
            .Aggregate(0L, ApplyScoreForToken);
        
        return score;
    }

    private static long ApplyScoreForToken(long score, char c)
    {
        score *= 5;
        score += CompletionTokenScore[c];
        return score;
    }

    public static long FindMiddleScore(IEnumerable<string> inputLines)
    {
        var completionScores = inputLines
            .Select(CalculateLineCompletionScoreForSingleLine)
            .Select(l => (double)l);
        
        var median = (long)completionScores.Median();
        
        return median;
    }
}