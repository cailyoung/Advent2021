namespace Day7;

public class SubmarineField
{
    public SubmarineField(IEnumerable<int> horizontalPositions)
    {
        Crabs = horizontalPositions.Select(p => new Crab(p));
    }

    private IEnumerable<Crab> Crabs { get; }
    private int MinHorizontalPosition => Crabs.Select(c => c.Position).Min();
    private int MaxHorizontalPosition => Crabs.Select(c => c.Position).Max();
    private IEnumerable<int> ListOfAllPotentialPositions => Enumerable.Range(MinHorizontalPosition, MaxHorizontalPosition - MinHorizontalPosition + 1);

    public int CheapestTargetPositionLinearFuelUsed => GetLinearFuelConsumptionValues()
        .Select(v => v.FuelConsumed)
        .Min();

    public int CheapestTargetPositionGeometricFuelUsed => GetGeometricFuelConsumptionValues()
        .Select(v => v.FuelConsumed)
        .Min();

    public IEnumerable<FuelConsumptionValue> GetLinearFuelConsumptionValues()
    {
        return ListOfAllPotentialPositions
            .Select(p => new FuelConsumptionValue(p, GetTotalLinearCrabConsumptionAtPosition(p)));
    }
    
    public IEnumerable<FuelConsumptionValue> GetGeometricFuelConsumptionValues()
    {
        return ListOfAllPotentialPositions
            .Select(p => new FuelConsumptionValue(p, GetTotalGeometricCrabConsumptionAtPosition(p)));
    }

    private int GetTotalGeometricCrabConsumptionAtPosition(int targetPosition)
    {
        // Triangle Numbers Weeeeeeeeeee!!!!
        return Crabs.Select(c => TriangleNumber(Math.Abs(targetPosition - c.Position))).Sum();
    }

    private static int TriangleNumber(int size)
    {
        return size * (size + 1) / 2;
    }

    private int GetTotalLinearCrabConsumptionAtPosition(int targetPosition)
    {
        return Crabs.Select(c => Math.Abs(targetPosition - c.Position)).Sum();
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