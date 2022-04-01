namespace Day7;

public class SubmarineField
{
    public SubmarineField(IEnumerable<int> horizontalPositions)
    {
        Crabs = horizontalPositions.Select(p => new Crab(p));
    }

    public IEnumerable<Crab> Crabs { get; }

    public int CheapestTargetPositionLinearFuelUsed => GetLinearFuelConsumptionValues()
        .Select(v => v.FuelConsumed)
        .Min();

    public int CheapestTargetPositionGeometricFuelUsed => GetGeometricFuelConsumptionValues()
        .Select(v => v.FuelConsumed)
        .Min();

    public IEnumerable<FuelConsumptionValue> GetLinearFuelConsumptionValues()
    {
        var minHorizontalPosition = Crabs.Select(c => c.Position).Min();
        var maxHorizontalPosition = Crabs.Select(c => c.Position).Max();
        var listOfAllPotentialPositions = Enumerable.Range(minHorizontalPosition, maxHorizontalPosition - minHorizontalPosition + 1);

        var fuelValues = listOfAllPotentialPositions
            .Select(p => new FuelConsumptionValue(p, GetTotalLinearCrabConsumptionAtPosition(p)));
        
        return fuelValues;
    }
    
    public IEnumerable<FuelConsumptionValue> GetGeometricFuelConsumptionValues()
    {
        var minHorizontalPosition = Crabs.Select(c => c.Position).Min();
        var maxHorizontalPosition = Crabs.Select(c => c.Position).Max();
        var listOfAllPotentialPositions = Enumerable.Range(minHorizontalPosition, maxHorizontalPosition - minHorizontalPosition + 1);
        
        var fuelValues = listOfAllPotentialPositions
            .Select(p => new FuelConsumptionValue(p, GetTotalGeometricCrabConsumptionAtPosition(p)));
        
        return fuelValues;
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