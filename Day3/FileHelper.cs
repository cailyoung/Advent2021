namespace Day3;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static IEnumerable<int[]> ParseInput(string[] input)
    {
        var returned = new List<int[]>();
        
        foreach (var row in input)
        {
            var transformedRow = row.ToCharArray()
                .Select(c => c.ToString())
                .Select(int.Parse).ToArray();
            returned.Add(transformedRow);
        }

        return returned;
    }
}