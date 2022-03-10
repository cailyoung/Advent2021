using System.Collections.Immutable;

namespace Day4;

public class GameOperations
{
    public static GameStep CallNextBingoNumber(GameStep previousStep)
    {
        if (previousStep.BingoNumbersToCall.Count == 0)
        {
            throw new ArgumentException("There are no numbers left to call.");
        }

        var numberToCall = previousStep.BingoNumbersToCall.First();

        return new GameStep(
            CallNumberOnBoards(numberToCall, previousStep.Boards),
            previousStep.BingoNumbersToCall.Skip(1).ToImmutableList());
    }

    private static List<BingoBoard> CallNumberOnBoards(int numberToCall, List<BingoBoard> boards)
    {
        return boards;
    }
}