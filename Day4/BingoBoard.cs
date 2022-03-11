namespace Day4;

public class BingoBoard
{
    private List<Position> Board { get; }
    public bool IsWinningBoard => CalculateIfWinning();
    public int TotalUncalledValues => UnCalledPositions().Sum(p => p.Value);

    public BingoBoard(List<Position> board)
    {
        Board = board;
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

    public List<Position> CalledPositions()
    {
        return Board.Where(p => p.Called).ToList();
    }

    public List<Position> UnCalledPositions()
    {
        return Board.Except(CalledPositions()).ToList();
    }

    public BingoBoard ApplyCalledNumber(BingoBoard oldBoard, int calledNumber)
    {
        var newBoard = new BingoBoard(oldBoard.Board);

        foreach (var position in newBoard.Board.Where(position => position.Value == calledNumber))
        {
            position.Called = true;
        }

        return newBoard;
    }
}