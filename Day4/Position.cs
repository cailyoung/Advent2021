namespace Day4;

public class Position
{
    public int Value { get; }
    public bool Called { get; set; }
    internal int CoordinateX { get; }
    internal int CoordinateY { get; }

    public Position(int coordinateX, int coordinateY, int value, bool called = false)
    {
        Value = value;
        Called = called;
        CoordinateX = coordinateX;
        CoordinateY = coordinateY;
    }

    public static IEnumerable<Position> GeneratePositionRow(IEnumerable<int> values, int rowNumber, bool called = false)
    {
        var valueArray = values.ToArray();
        
        return Enumerable
            .Range(0, valueArray.Length)
            .Select((_, i) => new Position(i, rowNumber, valueArray[i], called));
    }
}