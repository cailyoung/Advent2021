using System.Windows.Markup;

namespace Day4;

public class BingoBoard
{
    private List<Position> Board { get; }
    public bool IsWinningBoard => false;

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
        return Enumerable
            .Range(0, values.Count())
            .Select((v, i) => new Position(i, rowNumber, v, called));
    }
}
