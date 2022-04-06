namespace Day8;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }
    
    public static DataRow SplitInputLine(string inputLine)
    {
        var split = inputLine.Split("|", StringSplitOptions.TrimEntries);

        return new DataRow(split[0], split[1]);
    }

    public static IEnumerable<Digit> SplitDataRowSection(DataRow input)
    {
        return new List<Digit>();
    }
}

public class DataRow
{
    public string InputValues;
    public string OutputValues;

    public DataRow(string inputValues, string outputValues)
    {
        this.InputValues = inputValues;
        this.OutputValues = outputValues;
    }
}