using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;

namespace Day12;

public class CaveSystem
{
    private UndirectedGraph<Cave, UndirectedEdge<Cave>> CaveGraph;
    public int ValidPaths => CalculateValidPathCount();

    private int CalculateValidPathCount()
    {
        var algo = new UndirectedBreadthFirstSearchAlgorithm<Cave, UndirectedEdge<Cave>>(CaveGraph);
        var pathObserver = new UndirectedVertexPredecessorRecorderObserver<Cave, UndirectedEdge<Cave>>();
        pathObserver.Attach(algo);
        
        // algo.

        algo.Compute(new Cave("start"));

        return int.MinValue;
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