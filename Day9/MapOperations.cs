namespace Day9;

public static class MapOperations
{
    public static IEnumerable<Position> GetLowestPositions(HeightMap inputMap)
    {
        return inputMap.Map
            .Where(p => IsLowestPosition(p, inputMap));
    }

    public static int GetMapRisk(HeightMap inputMap)
    {
        return GetLowestPositions(inputMap)
            .Select(p => p.Height + 1)
            .Sum();
    }

    public static IEnumerable<Basin> FindAllBasins(HeightMap inputMap)
    {
        return new List<Basin>();
    }

    public static Position[] FindAllPositionsInBasin(Position startingPosition, HeightMap map)
    {
        var fullPositionList = new HashSet<Position>();
        var edgePositionList = new HashSet<Position?> {startingPosition};

        var exhausted = false;

        while (!exhausted)
        {
            if (edgePositionList.Any(p => p is not null))
            {
                fullPositionList.UnionWith(edgePositionList!);

                edgePositionList = edgePositionList
                    .Where(p => p is not null)
                    .SelectMany(p => GetSurroundingPositions(p!, map))
                    .Where(p => p is not null)
                    .Where(p => p!.Height != 9) // Height of 9 doesn't count for a basin
                    .ToHashSet();
            }

            if (edgePositionList.SetEquals(fullPositionList))
            {
                exhausted = true;
            }
        }
        
        return fullPositionList.ToArray();
    }
    
    private static bool IsLowestPosition(Position positionToCheck, HeightMap map)
    {
        var comparisonList = GetSurroundingPositions(positionToCheck, map);

        return comparisonList.Min(p => p?.Height ?? int.MaxValue) == positionToCheck.Height 
               && comparisonList.Count(p => p?.Height == positionToCheck.Height) == 1;
    }

    private static List<Position?> GetSurroundingPositions(Position positionToCheck, HeightMap map)
    {
        var xValue = positionToCheck.XValue;
        var yValue = positionToCheck.YValue;

        var above = map.Map.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue - 1, null);
        var below = map.Map.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue + 1, null);
        var left = map.Map.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue, null);
        var right = map.Map.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue, null);

        var comparisonList = new List<Position?>
        {
            positionToCheck,
            above,
            below,
            left,
            right
        };
        return comparisonList;
    }
}