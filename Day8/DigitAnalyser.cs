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
         *  Treating those as the 'names' of each segment, let's infer some early mappings based on the 
         *  currently-known digits (with unique segment counts)            
         *  
         * '7' == 3 segments (a - c - - f -)
         * '4' == 4 segments (- b c d - f -)
         * '1' == 2 segments (- - c - - f -)
         * '8' == 7 segments (a b c d e f g)
         *
         * Other digits will be:
         * '2' == 5 segments (a - c d e - g)
         * '3' == 5 segments (a - c d - f g)
         * '5' == 5 segments (a b - d - f g)
         *
         * '0' == 6 segments
         * '6' == 6 segments
         * '9' == 6 segments
         */
        
        var listOfUniqueSegmentChars = new List<Digit.Character>
        {
            Digit.Character.One, Digit.Character.Four, Digit.Character.Seven, Digit.Character.Eight
        };

        var dictOfInputsToChars = inputDigits
            .Where(d => listOfUniqueSegmentChars.Contains(d.CurrentCharacter))
            .ToDictionary(d => d.CurrentCharacter, d => d.OriginalString.ToList());

        var segmentAChar =
            dictOfInputsToChars[Digit.Character.Seven]
                .Except(dictOfInputsToChars[Digit.Character.One])
                .Single();

        return new Dictionary<Digit.Character, IEnumerable<char>>();
    }
}