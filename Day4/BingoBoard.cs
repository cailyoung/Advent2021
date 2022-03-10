namespace Day4;

public class BingoBoard
{
    private List<Position> Board { get; }
    public bool IsWinningBoard => CalculateIfWinning();

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
}