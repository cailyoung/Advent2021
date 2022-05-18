namespace Day11;

public static class MapOperations
{
    public static (EnergyMap EnergyMap, int FlashCount) ProduceNextStep(EnergyMap startingMap)
    {
        var workingMap = startingMap
            .IncrementAllMapEnergyValues()
            .FlashAllOverNineEnergy();
            
        var stepFlashCount = workingMap.Map.Count(p => p.CurrentlyFlashing);
        
        return (workingMap.SetFlashedOctopusEnergiesToZero(), stepFlashCount);
    }

    public static IEnumerable<(EnergyMap EnergyMap, int FlashCount)> ProduceFutureStepState(EnergyMap startingMap, int afterStepNumber)
    {
        var workingMaps = new List<(EnergyMap EnergyMap, int FlashCount)> { new (startingMap, startingMap.Map.Count(p => p.CurrentlyFlashing)) };
        var stepsRemaining = afterStepNumber;

        while (stepsRemaining > 0)
        {
            workingMaps.Add(ProduceNextStep(workingMaps.Last().EnergyMap));
            stepsRemaining--;
        }

        return workingMaps;
    }

    public static int CalculateStepWhenAllFlash(EnergyMap startingMap)
    {
        var workingMap = startingMap;
        var stepCount = 0;
        
        while (workingMap.Map.Any(p => p.Energy != 0))
        {
            workingMap = ProduceNextStep(workingMap).EnergyMap;
            stepCount++;
        }

        return stepCount;
    }

    private static EnergyMap IncrementAllMapEnergyValues(this EnergyMap startingMap)
    {
        return new EnergyMap(startingMap.Map.Select(IncrementPositionEnergy));
    }

    private static Position IncrementPositionEnergy(Position startingPosition)
    {
        return startingPosition with { Energy = startingPosition.Energy + 1 };
    }

    private static EnergyMap FlashAllOverNineEnergy(this EnergyMap startingMap)
    {
        var workingMap = new EnergyMap(startingMap.Map);
        var alreadyFlashedCoOrds = new HashSet<CoOrd>();

        var exhausted = false;

        while (!exhausted)
        {
            var newToFlashCoOrds = workingMap.Map
                .Where(PositionIsNewlyFlashing())
                .Select(p => p.CoOrd)
                .ToList();

            switch (newToFlashCoOrds.Any())
            {
                case true:
                    workingMap = ApplyFlashingCoOrdsToWorkingMap(newToFlashCoOrds, workingMap);
                    alreadyFlashedCoOrds.UnionWith(newToFlashCoOrds);
                    break;
                case false:
                    exhausted = true;
                    break;
            }
            
            Func<Position, bool> PositionIsNewlyFlashing()
            {
                return p => p.CurrentlyFlashing && !alreadyFlashedCoOrds.Contains(p.CoOrd);
            }
        }
        
        return workingMap;
    }

    private static EnergyMap SetFlashedOctopusEnergiesToZero(this EnergyMap workingMap)
    {
        var zeroedMap = workingMap.Map.Select(position => position.CurrentlyFlashing ? position with { Energy = 0 } : position);

        return new EnergyMap(zeroedMap);
    }

    private static EnergyMap ApplyFlashingCoOrdsToWorkingMap(List<CoOrd> newToFlashCoOrds, EnergyMap workingMap)
    {
        var workingMapPositions = workingMap.Map.ToList();
        
        foreach (var coOrd in newToFlashCoOrds)
        {
            var incrementedPositions = 
                GetSurroundingPositions(coOrd, workingMapPositions)
                .Select(IncrementPositionEnergy)
                .ToList();

            var positionsWithoutOldPositions = workingMapPositions.Except(incrementedPositions).ToList();

            positionsWithoutOldPositions.AddRange(incrementedPositions);

            workingMapPositions = positionsWithoutOldPositions;
        }

        return new EnergyMap(workingMapPositions);
    }

    private static IEnumerable<Position> GetSurroundingPositions(CoOrd coOrdToCheck, List<Position> positionList)
    {
        var xValue = coOrdToCheck.XValue;
        var yValue = coOrdToCheck.YValue;

        /*
         *
         * aboveleft above aboveright
         *   left      *   right
         * belowleft below belowright
         *
         */
        
        var above = positionList.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue - 1, null);
        var below = positionList.SingleOrDefault(p => p!.XValue == xValue && p.YValue == yValue + 1, null);
        var left = positionList.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue, null);
        var right = positionList.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue, null);
        var aboveLeft = positionList.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue - 1, null);
        var aboveRight = positionList.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue - 1, null);
        var belowLeft = positionList.SingleOrDefault(p => p!.XValue == xValue - 1 && p.YValue == yValue + 1, null);
        var belowRight = positionList.SingleOrDefault(p => p!.XValue == xValue + 1 && p.YValue == yValue + 1, null);

        var comparisonList = new List<Position?>
        {
            positionList.Single(p => p.CoOrd == coOrdToCheck),
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