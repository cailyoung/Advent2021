using System.Collections.Immutable;

namespace Day5;

public class MapGrid
{
    public ImmutableList<CoOrd> CurrentMapGrid { get; }

    public MapGrid(IEnumerable<VentLine> currentVentLines)
    {
        var ventLines = currentVentLines.ToList();
        if (ventLines.Any(line => line.Diagonal))
        {
            throw new ArgumentException("Grids can only be built from horizontal and vertical lines");
        }

        var workingList = ventLines.SelectMany(c => c.LineCoOrds);

        CurrentMapGrid = workingList.ToImmutableList();
    }

}