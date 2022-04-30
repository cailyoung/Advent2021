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

        var openers = new Stack<char>();
        bool? validCloser = null;

        foreach (var token in workingArray)
        {
            switch (ValidOpeners.Contains(token))
            {
                case true:
                    openers.Push(token);
                    break;
                case false:
                    validCloser = ValidTokenPairs.Single(pair => pair.Closer == token).Opener == openers.Pop();
                    break;
            }

            if (validCloser is null || (bool)validCloser) continue;
            
            failingToken = token.ToString();
            break;
        }
        
        return failingToken;
    }

    public static IEnumerable<string> FindCorruptLines(IEnumerable<string> input)
    {
        return new List<string>();
    }
}