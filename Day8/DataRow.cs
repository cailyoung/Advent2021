namespace Day8;

public class DataRow
{
    public readonly string InputValues;
    public readonly string OutputValues;
    public readonly IDictionary<Digit.Character, char[]>? CharacterMapping;

    public DataRow(string inputValues, string outputValues, IDictionary<Digit.Character, char[]>? characterMapping = null)
    {
        InputValues = inputValues;
        OutputValues = outputValues;
        CharacterMapping = characterMapping;
    }

    public static IEnumerable<DataRow> GenerateMappedDataRows(IEnumerable<DataRow> unmappedDataRows)
    {
        return unmappedDataRows.Select(dr => 
            new DataRow(
                dr.InputValues,
                dr.OutputValues, 
                DigitAnalyser.GenerateCharacterMappings(FileHelper.SplitDataRowSection(dr.InputValues))
            )
        );
    }

    public static int GenerateOutputSectionNumber(IEnumerable<Digit> outputSection)
    {
        var combinedString = string.Concat(outputSection
            .Select(d => MapCharacterToDigit(d.CurrentCharacter)));

        return Convert.ToInt32(combinedString);
    }

    private static char MapCharacterToDigit(Digit.Character character)
    {
        return character switch
        {
            Digit.Character.Zero => '0',
            Digit.Character.One => '1',
            Digit.Character.Two => '2',
            Digit.Character.Three => '3',
            Digit.Character.Four => '4',
            Digit.Character.Five => '5',
            Digit.Character.Six => '6',
            Digit.Character.Seven => '7',
            Digit.Character.Eight => '8',
            Digit.Character.Nine => '9',
            Digit.Character.Unknown => '?',
            _ => throw new ArgumentOutOfRangeException(nameof(character))
        };
    }
}