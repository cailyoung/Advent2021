using QuikGraph;

namespace Day12;

public static class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static CaveSystem ParseInput(string[] inputLines)
    {
        return new CaveSystem(new UndirectedGraph<Cave, Edge<Cave>>());
    }
}