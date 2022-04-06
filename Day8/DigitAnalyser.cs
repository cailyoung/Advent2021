namespace Day8;

public class DigitAnalyser
{
    public static int CalculateNumberOfUniqueSegmentCountDigits(IEnumerable<Digit> inputDigits)
    {
        return inputDigits.Count(d => d.CurrentCharacter != Digit.Character.Unknown);
    }
}