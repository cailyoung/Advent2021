namespace Day9;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static HeightMap GenerateInitialHeightMap(string[] input)
    {
        return new HeightMap(new List<Position>());
    }
}