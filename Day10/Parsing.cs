namespace Day10;

public static class Parsing
{
    private static readonly List<TokenPair> ValidTokenPairs = new List<TokenPair>()
    {
        new('(', ')'),
        new('[', ']'),
        new('{', '}'),
        new('<', '>')
    };

    private static readonly HashSet<char> ValidOpeners = new HashSet<char>()
    {
        '(',
        '[',
        '{',
        '<'
    };
    
    private static readonly HashSet<char> ValidClosers = new HashSet<char>()
    {
        ')',
        ']',
        '}',
        '>'
    };

    public static string FindFirstCorruptToken(string inputLine)
    {
        var workingArray = inputLine.ToCharArray();
        var failingToken = string.Empty;
        
        for (var potentialCloserIndex = 0; potentialCloserIndex < workingArray.Length; potentialCloserIndex++)
        {
            if (ValidOpeners.Contains(workingArray[potentialCloserIndex])) 
                continue;
            for (var potentialOpenerIndex = potentialCloserIndex - 1; potentialOpenerIndex >= 0; potentialOpenerIndex--)
            {
                var currentCloser = workingArray[potentialCloserIndex];
                var currentOpener = workingArray[potentialOpenerIndex];
                var matched = currentOpener == ValidTokenPairs.Single(p => p.Closer == currentCloser).Opener;
                if (matched)
                {
                    workingArray.ToList().RemoveRange(potentialOpenerIndex, 2);
                    continue;
                }

                failingToken = currentCloser.ToString();
                break;
            }
        }
        
        return failingToken;
    }
}