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
        
        var failingToken = string.Empty;
        failingToken = RemoveMatchedTokenPairs(inputLine, failingToken);

        return failingToken;
    }

    private static string RemoveMatchedTokenPairs(string inputLine, string failingToken)
    {
        var workingArray = inputLine.ToCharArray();
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
                    validCloser = GetOpenerForCloser(token) == openers.Pop();
                    break;
            }

            if (validCloser is null || (bool)validCloser) continue;

            failingToken = token.ToString();
            break;
        }

        return failingToken;
    }

    private static char GetOpenerForCloser(char token)
    {
        return ValidTokenPairs.Single(pair => pair.Closer == token).Opener;
    }
    
    private static char GetCloserForOpener(char token)
    {
        return ValidTokenPairs.Single(pair => pair.Opener == token).Closer;
    }

    public static string GenerateClosingSequence(string incompleteLine)
    {
        if (FindFirstCorruptToken(incompleteLine) != string.Empty)
        {
            throw new ArgumentException("Input line contained an incorrect closing token, please check your input");
        }

        var workingArray = incompleteLine.ToCharArray();
        var unclosedOpeners = new Stack<char>();
        bool? validCloser = null;
        
        foreach (var token in workingArray)
        {
            switch (ValidOpeners.Contains(token))
            {
                case true:
                    unclosedOpeners.Push(token);
                    break;
                case false:
                    validCloser = GetOpenerForCloser(token) == unclosedOpeners.Pop();
                    break;
            }

            if (validCloser is null || (bool)validCloser) continue;
            
            break;
        }

        var closers = new Stack<char>();

        while (unclosedOpeners.Any())
        {
            closers.Push(GetCloserForOpener(unclosedOpeners.Pop()));
        }

        var closingSequence = string.Concat(closers.Reverse());
        
        return closingSequence;
    }
    
    public static IEnumerable<string> FindCorruptLines(IEnumerable<string> input)
    {
        return input.Where(s => FindFirstCorruptToken(s) != string.Empty);
    }

    public static IEnumerable<string> FindIncompleteLines(IEnumerable<string> input)
    {
        return input.Where(s => FindFirstCorruptToken(s) == string.Empty);
    }
}