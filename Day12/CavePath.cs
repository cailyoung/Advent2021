namespace Day12;

public class CavePath
{
    public readonly List<Cave> PathNodes;
    public bool CompletePath => PathNodes.Last().CaveType == CaveType.End;

    public CavePath(Cave startingCave)
    {
        PathNodes = new List<Cave> {startingCave};
    }

    private CavePath(IEnumerable<Cave> pathNodes)
    {
        PathNodes = pathNodes.ToList();
    }

    public bool CanAddCave(Cave candidateCave, bool isPartTwo)
    {
        if (CompletePath)
        {
            return false;
        }
        
        return !isPartTwo ? PartOneCanAddCave(candidateCave) : PartTwoCanAddCave(candidateCave);
    }

    private bool PartTwoCanAddCave(Cave candidateCave)
    {
        throw new NotImplementedException();
    }

    private bool PartOneCanAddCave(Cave candidateCave)
    {
        switch (candidateCave.CaveType)
        {
            case CaveType.Start:
                return false;
            case CaveType.End:
                return true;
            case CaveType.Small:
                // Small caves can only be visited once
                return PathNodes.All(c => c.Token != candidateCave.Token);
            case CaveType.Big:
                // Large caves can be visited any number of times
                return true;
            case CaveType.Unknown:
            default:
                throw new ArgumentOutOfRangeException(nameof(candidateCave.CaveType));
        }
    }

    public CavePath AddCave(Cave caveToAdd)
    {
        if (!CanAddCave(caveToAdd, false))
        {
            throw new ArgumentException("Cave cannot be added as it is invalid");
        }

        return new CavePath(new List<Cave>(PathNodes) { caveToAdd });
    }
}