namespace Day7;

public class SubmarineField
{
    public SubmarineField(IEnumerable<Crab> crabs)
    {
        Crabs = crabs;
    }

    public SubmarineField(IEnumerable<int> horizontalPositions)
    {
        Crabs = horizontalPositions.Select(p => new Crab(p));
    }

    public IEnumerable<Crab> Crabs { get; }
}