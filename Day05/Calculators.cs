using System.Collections.Immutable;

namespace Day5;

public class Calculators
{
    public static ImmutableList<(CoOrd coOrd, int overlapCount)> Overlaps(MapGrid currentGrid)
    {
        return currentGrid.CurrentMapGrid
            .GroupBy(c => c.CompoundCoordinate)
            .Select(row => new ValueTuple<CoOrd, int>(row.First(), row.Count()))
            .ToImmutableList();
    }
}