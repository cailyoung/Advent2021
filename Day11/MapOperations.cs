namespace Day11;

public static class MapOperations
{
    public static EnergyMap ProduceNextStep(EnergyMap startingMap)
    {
        var workingMap = startingMap
            .IncrementAllMapEnergyValues()
            .FlashAllOverNineEnergy();
        
        return workingMap;
    }

    private static EnergyMap IncrementAllMapEnergyValues(this EnergyMap startingMap)
    {
        return new EnergyMap(startingMap.Map.Select(p => p with { Energy = p.Energy + 1 }));
    }

    private static Position IncrementPositionEnergy(Position startingPosition)
    {
        return startingPosition with { Energy = startingPosition.Energy + 1 };
    }

    private static EnergyMap FlashAllOverNineEnergy(this EnergyMap startingMap)
    {
        var workingMap = new EnergyMap(startingMap.Map);
        var flashedCoOrds = new HashSet<CoOrd>();

        var exhausted = false;

        while (!exhausted)
        {
            var currentlyFlashingPositions = workingMap.Map.Where(p => p.CurrentlyFlashing).ToArray();
            
            var positionsToFlashNext = currentlyFlashingPositions
                .SelectMany(position => GetSurroundingPositions(position, workingMap))
                .Distinct();
            
            flashedCoOrds.UnionWith(currentlyFlashingPositions.Select(p => p.CoOrd));
            
            var newFlashedPositions = positionsToFlashNext.Select(IncrementPositionEnergy).ToArray();

            var newWorkingMapPositions = workingMap.Map
                .ExceptBy(newFlashedPositions.Select(p => p.CoOrd), position => position.CoOrd)
                .ToList();

            newWorkingMapPositions.AddRange(newFlashedPositions);

            workingMap = new EnergyMap(newWorkingMapPositions);

            if (flashedCoOrds.SetEquals(workingMap.Map.Where(p => p.CurrentlyFlashing).Select(p => p.CoOrd)))
            {
                exhausted = true;
            }
        }

        return workingMap;
    }
    
    private static IEnumerable<Position> GetSurroundingPositions(Position positionToCheck, EnergyMap map)
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
        
        return comparisonList.Where(p => p is not null)!;
    }
}