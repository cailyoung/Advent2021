using System.Collections.Immutable;

namespace Day5;

public class MapGrid
{
    public ImmutableList<CoOrd> CurrentMapGrid { get; }

    public MapGrid(IEnumerable<VentLine> currentVentLines)
    {
        if (currentVentLines.Any(line => !line.Horizontal || !line.Vertical))
        {
            throw new ArgumentException("Grids can only be built from horizontal and vertical lines");
        }
    }

}