using System.Collections.Immutable;

namespace Day4;

public class GameStep
{
    public ImmutableList<BingoBoard> Boards { get; }

    public ImmutableList<int> BingoNumbersToCall { get; }

    public GameStep(ImmutableList<BingoBoard> boards, ImmutableList<int> bingoNumbersToCall)
    {
        Boards = boards;
        BingoNumbersToCall = bingoNumbersToCall;
    }
}