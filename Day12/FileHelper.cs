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
        var workingGraph = new UndirectedGraph<Cave, UndirectedEdge<Cave>>();

        foreach (var inputLine in inputLines)
        {
            var splitLine = inputLine
                .Split('-')
                .Select(t => new Cave(t))
                .OrderBy(c => c)
                .ToList();
            workingGraph.AddVerticesAndEdge(new UndirectedEdge<Cave>(splitLine.First(), splitLine.Last()));
        }

        return new CaveSystem(workingGraph);
    }
}