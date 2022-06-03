using QuikGraph;

namespace Day12;

public class CaveSystem
{
    private readonly UndirectedGraph<Cave, UndirectedEdge<Cave>> CaveGraph;
    public int ValidPartOnePaths => CalculateValidPathCount(false);
    public int ValidPartTwoPaths => CalculateValidPathCount(true);
    private readonly HashSet<CavePath> PartOneCavePaths;
    private readonly HashSet<CavePath> PartTwoCavePaths;

    private int CalculateValidPathCount(bool isPartTwo)
    {
        return !isPartTwo ? GeneratePartOnePathCount(isPartTwo) : GeneratePartTwoPathCount(isPartTwo);
    }

    private int GeneratePartTwoPathCount(bool isPartTwo)
    {
        while (PartTwoCavePaths.Any(p => !p.CompletePath))
        {
            var pathsToExtend = PartTwoCavePaths
                .Where(p => !p.CompletePath)
                .ToArray();

            foreach (var path in pathsToExtend)
            {
                PartTwoCavePaths.Remove(path);
                foreach (var newPath in GenerateNextStepPaths(path, isPartTwo)) PartTwoCavePaths.Add(newPath);
            }
        }

        return PartTwoCavePaths.Count;    
    }

    private int GeneratePartOnePathCount(bool isPartTwo)
    {
        while (PartOneCavePaths.Any(p => !p.CompletePath))
        {
            var pathsToExtend = PartOneCavePaths
                .Where(p => !p.CompletePath)
                .ToArray();

            foreach (var path in pathsToExtend)
            {
                PartOneCavePaths.Remove(path);
                foreach (var newPath in GenerateNextStepPaths(path, isPartTwo)) PartOneCavePaths.Add(newPath);
            }
        }

        return PartOneCavePaths.Count;
    }

    public CaveSystem(UndirectedGraph<Cave, UndirectedEdge<Cave>> caveGraph)
    {
        CaveGraph = caveGraph;
        PartOneCavePaths = new HashSet<CavePath> { new(new Cave("start")) };
        PartTwoCavePaths = new HashSet<CavePath> { new(new Cave("start")) };
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
            .Select(candidateCave => startingPath.AddCave(candidateCave, isPartTwo));

        return nextCaves;
    }
}