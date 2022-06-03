using System.Xml;

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
        switch (candidateCave.CaveType)
        {
            case CaveType.Start:
                return false;
            case CaveType.End:
                return true;
            case CaveType.Small:
                // Small caves can only be visited once, unless they're the first one to be hit twice
                return PartTwoSmallCaveCheckForAdmission(candidateCave);
            case CaveType.Big:
                // Large caves can be visited any number of times
                return true;
            case CaveType.Unknown:
            default:
                throw new ArgumentOutOfRangeException(nameof(candidateCave.CaveType));
        }
    }

    private bool PartTwoSmallCaveCheckForAdmission(Cave candidateCave)
    {
        // if candidate token is already there twice, NO
        // if it's already there once, check if there is another token there twice, if so, NO, otherwise YES
        // if it's not there, add it

        var candidateAlreadyThereAtLeastTwice = PathNodes.Count(c => c.Token == candidateCave.Token) >= 2;
        var candidateAlreadyThereOnce = PathNodes.Count(c => c.Token == candidateCave.Token) == 1;
        var existingTwiceVisitedCave = PathNodes
            .GroupBy(c => c.Token)
            .Select(g => new { Key = g.Key, Count = g.Count() })
            .FirstOrDefault(g => g.Count == 2);

        var thisIsABrandNewCave = PathNodes.All(c => c.Token != candidateCave.Token);

        if (thisIsABrandNewCave) return true;

        if (candidateAlreadyThereAtLeastTwice) return false;

        if (candidateAlreadyThereOnce && existingTwiceVisitedCave is null)
        {
            return true;
        }
        
        return false;
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

    public CavePath AddCave(Cave caveToAdd, bool isPartTwo)
    {
        if (!CanAddCave(caveToAdd, isPartTwo))
        {
            throw new ArgumentException("Cave cannot be added as it is invalid");
        }

        return new CavePath(new List<Cave>(PathNodes) { caveToAdd });
    }
}