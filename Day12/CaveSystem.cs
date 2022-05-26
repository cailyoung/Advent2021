using QuikGraph;

namespace Day12;

public class CaveSystem
{
    private UndirectedGraph<Cave, Edge<Cave>> CaveGraph;
    public int ValidPaths => CalculateValidPathCount();

    private int CalculateValidPathCount()
    {
        throw new NotImplementedException();
    }

    public CaveSystem(UndirectedGraph<Cave, Edge<Cave>> caveGraph)
    {
        CaveGraph = caveGraph;
    }
}

public record Cave
{
    CaveType caveType;
}

public enum CaveType
{
    Start,
    End,
    Small,
    Big
}