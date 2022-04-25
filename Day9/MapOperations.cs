namespace Day9;

public static class MapOperations
{
    public static IEnumerable<Position> GetLowestPositions(HeightMap inputMap)
    {
        return inputMap.Map
            .Where(p => IsLowestPosition(p, inputMap))
            .Select(p => p with { Lowest = true });
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
        return Array.Empty<Position>();
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