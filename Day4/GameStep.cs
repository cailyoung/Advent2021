using System.Collections.Immutable;

namespace Day4;

public class GameStep
{
    public List<BingoBoard> Boards { get; }

    public ImmutableList<int> BingoNumbersToCall { get; }

    public GameStep(List<BingoBoard> boards, ImmutableList<int> bingoNumbersToCall)
    {
        Boards = boards;
        BingoNumbersToCall = bingoNumbersToCall;
    }
}