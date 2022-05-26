using QuikGraph;

namespace Day12;

public class CaveSystem
{
    private UndirectedGraph<Cave, UndirectedEdge<Cave>> CaveGraph;
    public int ValidPaths => CalculateValidPathCount();

    private int CalculateValidPathCount()
    {
        throw new NotImplementedException();
    }

    public CaveSystem(UndirectedGraph<Cave, UndirectedEdge<Cave>> caveGraph)
    {
        CaveGraph = caveGraph;
    }
}

public enum CaveType
{
    Unknown,
    Start,
    End,
    Small,
    Big
}