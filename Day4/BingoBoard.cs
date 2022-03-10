namespace Day4;

public class BingoBoard
{
    private List<Position> Board { get; }
    public bool IsWinningBoard => CalculateIfWinning();

    public BingoBoard(List<Position> board)
    {
        Board = board;
    }

    public IEnumerable<Position> GetRow (int rowNumber)
    {
        return Board.Where(position => position.CoordinateY == rowNumber);
    }
    
    public IEnumerable<Position> GetColumn (int rowNumber)
    {
        return Board.Where(position => position.CoordinateX == rowNumber);
    }

    private bool CalculateIfWinning()
    {
        var columnGroups = Board.GroupBy(position => position.CoordinateX);
        var winningColumns = columnGroups.Where(c => c.All(position => position.Called));
        var columnWinCondition = winningColumns.Any();
        
        var rowGroups = Board.GroupBy(position => position.CoordinateY);
        var winningRows = rowGroups.Where(c => c.All(position => position.Called));
        var rowWinCondition = winningRows.Any();


        return columnWinCondition || rowWinCondition;
    }
}

public class Position
{
    private int Value { get; }
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
