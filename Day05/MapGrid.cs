using System.Collections.Immutable;

namespace Day5;

public class MapGrid
{
    public ImmutableList<CoOrd> CurrentMapGrid { get; }

    public MapGrid(IEnumerable<VentLine> currentVentLines)
    {
        var ventLines = currentVentLines.ToList();

        var workingList = ventLines.SelectMany(c => c.LineCoOrds);

        CurrentMapGrid = workingList.ToImmutableList();
    }

}