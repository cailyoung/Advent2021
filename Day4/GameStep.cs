using System.Collections.Immutable;

namespace Day4;

public class GameStep
{
    public ImmutableList<BingoBoard> Boards { get; }

    public ImmutableList<int> BingoNumbersToCall { get; }
    
    public int? LastCalledNumber { get; }

    public GameStep(ImmutableList<BingoBoard> boards, ImmutableList<int> bingoNumbersToCall, int? lastCalledNumber = null)
    {
        Boards = boards;
        BingoNumbersToCall = bingoNumbersToCall;
        LastCalledNumber = lastCalledNumber;
    }
}