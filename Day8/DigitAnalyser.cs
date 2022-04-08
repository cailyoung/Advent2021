namespace Day8;

public static class DigitAnalyser
{
    public static int CalculateNumberOfUniqueSegmentCountDigits(IEnumerable<Digit> inputDigits)
    {
        return inputDigits.Count(d => d.CurrentCharacter != Digit.Character.Unknown);
    }

    public static IDictionary<string, Digit.Character> GenerateCharacterMappings(IEnumerable<Digit> inputDigits)
    {
        return new Dictionary<string, Digit.Character>();
    }
}