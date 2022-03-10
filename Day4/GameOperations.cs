using System.Collections.Immutable;

namespace Day4;

public static class GameOperations
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
            previousStep.BingoNumbersToCall.Skip(1).ToImmutableList(),
            numberToCall);
    }

    private static ImmutableList<BingoBoard> CallNumberOnBoards(int numberToCall, ImmutableList<BingoBoard> boards)
    {
        return new List<BingoBoard>(boards
            .Select(board => board.ApplyCalledNumber(board, numberToCall)))
            .ToImmutableList();
    }

    public static GameStep RunGameUntilWin(GameStep initialGameStep)
    {
        var gameOver = false;
        var currentGameStep = new GameStep(initialGameStep.Boards, initialGameStep.BingoNumbersToCall);
        while (gameOver == false)
        {
            currentGameStep = CallNextBingoNumber(currentGameStep);
            gameOver = currentGameStep.Boards.Exists(board => board.IsWinningBoard);
        }

        return currentGameStep;
    }
}