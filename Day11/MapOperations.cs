namespace Day11;

public static class MapOperations
{
    public static EnergyMap ProduceNextStep(EnergyMap startingMap)
    {
        return new EnergyMap(new List<Position>());
    }
    
    private static List<Position?> GetSurroundingPositions(Position positionToCheck, EnergyMap map)
    {
        var xValue = positionToCheck.XValue;
        var yValue = positionToCheck.YValue;

        /*
         *
         * aboveleft above aboveright
         *   left      *   right
         * belowleft below belowright
         *
         */
        
        var above = map.Map.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue - 1, null);
        var below = map.Map.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue + 1, null);
        var left = map.Map.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue, null);
        var right = map.Map.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue, null);
        var aboveLeft = map.Map.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue - 1, null);
        var aboveRight = map.Map.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue - 1, null);
        var belowLeft = map.Map.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue + 1, null);
        var belowRight = map.Map.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue + 1, null);

        var comparisonList = new List<Position?>
        {
            positionToCheck,
            above,
            below,
            left,
            right,
            aboveLeft,
            aboveRight,
            belowLeft,
            belowRight
        };
        return comparisonList;
    }
}