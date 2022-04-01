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

    public IEnumerable<FuelConsumptionValue> GetFuelConsumptionValues()
    {
        return new[] { new FuelConsumptionValue(default, default) };
    }
}

public class FuelConsumptionValue
{
    public FuelConsumptionValue(int targetPosition, int fuelConsumed)
    {
        TargetPosition = targetPosition;
        FuelConsumed = fuelConsumed;
    }

    public int TargetPosition { get; }
    public int FuelConsumed { get; }
}