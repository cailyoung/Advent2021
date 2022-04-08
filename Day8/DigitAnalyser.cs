namespace Day8;

public static class DigitAnalyser
{
    public static int CalculateNumberOfUniqueSegmentCountDigits(IEnumerable<Digit> inputDigits)
    {
        return inputDigits.Count(d => d.CurrentCharacter != Digit.Character.Unknown);
    }

    public static IDictionary<Digit.Character, IEnumerable<char>> GenerateCharacterMappings(IEnumerable<Digit> inputDigits)
    {
        /*
         * SEGMENT MAPPING:
         *  aaaa 
         * b    c
         * b    c
         *  dddd 
         * e    f
         * e    f
         *  gggg 
         *            
         *  
         * '7' == 3 segments (a - c - - f -)
         * '4' == 4 segments (- b c d - f -)
         * '1' == 2 segments (- - c - - f -)
         * '8' == 7 segments (a b c d e f g)
         * Totals            (2 2 4 2 1 4 1)
         *
         * Other digits will be:
         * '2' == 5 segments (a - c d e - g)
         * '3' == 5 segments (a - c d - f g)
         * '5' == 5 segments (a b - d - f g)
         *                   (3 1 2 3 1 2 3)
         *
         * '0' == 6 segments (a b c - e f g)
         * '6' == 6 segments (a b - d e f g)
         * '9' == 6 segments (a b c d - f g)
         *                   (3 3 2 2 2 3 3)
         *
         * Total counts in just the 'unknowns' are:
         *                   (6 4 4 5 3 5 6)
         * 
         * Total counts of each segment overall are:
         *                   (8 6 8 7 4 9 7)
         *
         * Segment A: (2,6)
         * Segment B: (2,4)
         * Segment C: (4,4)
         * Segment D: (2,5)
         * Segment E: (1,3)
         * Segment F: (4,5)
         * Segment G: (1,6)
         *
         * Count of chars across 'all uniques' and 'all unknowns' can identify the target segment :woohoo:
         */

        var charCountDecoderLookup = new Dictionary<string, char>
        {
            { "26", 'a' },
            { "24", 'b' },
            { "44", 'c' },
            { "25", 'd' },
            { "13", 'e' },
            { "45", 'f' },
            { "16", 'g' }
        };

        var listOfUniqueSegmentChars = new HashSet<Digit.Character>
        {
            Digit.Character.One, Digit.Character.Four, Digit.Character.Seven, Digit.Character.Eight
        };

        var workingArray = inputDigits.ToArray();
        
        var uniqueSegmentCharCounts = workingArray
            .Where(d => listOfUniqueSegmentChars.Contains(d.CurrentCharacter))
            .SelectMany(d => d.OriginalString.ToList())
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());
        
        var unknownSegmentCharCounts= workingArray
            .Where(d => !listOfUniqueSegmentChars.Contains(d.CurrentCharacter))
            .SelectMany(d => d.OriginalString.ToList())
            .GroupBy(c => c)
            .ToDictionary(g => g.Key, g => g.Count());

        var charArray = "abcdefg".ToArray();

        var encodedCharCountLookup = charArray
            .ToDictionary(c => c, c => string.Concat(uniqueSegmentCharCounts[c], unknownSegmentCharCounts[c]));

        var decodeMapper = charArray
            .Select(c => new CharMapper
                (c, charCountDecoderLookup[encodedCharCountLookup[c]]));
        
        return new Dictionary<Digit.Character, IEnumerable<char>>();
    }
}

public class CharDecoderKey
{
    private int UniqueSegmentCharCount;
    private int UnknownSegmentCharCount;

    public CharDecoderKey(int uniqueSegmentCharCount, int unknownSegmentCharCount)
    {
        UniqueSegmentCharCount = uniqueSegmentCharCount;
        UnknownSegmentCharCount = unknownSegmentCharCount;
    }
}

public class CharDecoderSegmentName
{
    public char SegmentName;

    public CharDecoderSegmentName(char segmentName)
    {
        SegmentName = segmentName;
    }
}

public class EncodedSegmentName
{
    private char SegmentName;

    public EncodedSegmentName(char segmentName)
    {
        SegmentName = segmentName;
    }
}

public class CharMapper
{
    private char EncodedSegmentName;
    private char DecodedSegmentName;

    public CharMapper(char encodedSegmentName, char decodedSegmentName)
    {
        EncodedSegmentName = encodedSegmentName;
        DecodedSegmentName = decodedSegmentName;
    }
}