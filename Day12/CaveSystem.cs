using QuikGraph;

namespace Day12;

public class CaveSystem
{
    private readonly UndirectedGraph<Cave, UndirectedEdge<Cave>> CaveGraph;
    public int ValidPaths => CalculateValidPathCount();
    private readonly HashSet<CavePath> CavePaths;

    private int CalculateValidPathCount()
    {
        while (CavePaths.Any(p => !p.CompletePath))
        {
            var pathsToExtend = CavePaths
                .Where(p => !p.CompletePath)
                .ToArray();

            foreach (var path in pathsToExtend)
            {
                CavePaths.Remove(path);
                foreach (var newPath in GenerateNextStepPaths(path)) CavePaths.Add(newPath);
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

    private IEnumerable<CavePath> GenerateNextStepPaths(CavePath startingPath)
    {
        var nextCaves = CaveGraph
            .AdjacentVertices(startingPath.PathNodes.Last())
            .Where(startingPath.CanAddCave)
            .Select(startingPath.AddCave);

        return nextCaves;
    }
}