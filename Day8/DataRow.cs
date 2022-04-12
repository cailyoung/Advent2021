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
}