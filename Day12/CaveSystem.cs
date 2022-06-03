using QuikGraph;

namespace Day12;

public class CaveSystem
{
    private readonly UndirectedGraph<Cave, UndirectedEdge<Cave>> CaveGraph;
    public int ValidPartOnePaths => CalculateValidPathCount(false);
    public int ValidPartTwoPaths => CalculateValidPathCount(true);
    private readonly HashSet<CavePath> CavePaths;

    private int CalculateValidPathCount(bool isPartTwo)
    {
        while (CavePaths.Any(p => !p.CompletePath))
        {
            var pathsToExtend = CavePaths
                .Where(p => !p.CompletePath)
                .ToArray();

            foreach (var path in pathsToExtend)
            {
                CavePaths.Remove(path);
                foreach (var newPath in GenerateNextStepPaths(path, isPartTwo)) CavePaths.Add(newPath);
            }
        }

        return CavePaths.Count;
    }

    public CaveSystem(UndirectedGraph<Cave, UndirectedEdge<Cave>> caveGraph)
    {
        CaveGraph = caveGraph;
        CavePaths = new HashSet<CavePath> { new(new Cave("start")) };
        if (CaveGraph.Vertices.Any(c => c.CaveType == CaveType.Unknown))
        {
            throw new ArgumentException("Cave tokens must be either 'start', 'end', or a string of all-upper or all-lower case characters");
        }
    }

    private IEnumerable<CavePath> GenerateNextStepPaths(CavePath startingPath, bool isPartTwo)
    {
        var nextCaves = CaveGraph
            .AdjacentVertices(startingPath.PathNodes.Last())
            .Where(candidateCave => startingPath.CanAddCave(candidateCave, isPartTwo))
            .Select(startingPath.AddCave);

        return nextCaves;
    }
}