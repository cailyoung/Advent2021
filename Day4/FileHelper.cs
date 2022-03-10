using System.Collections.Immutable;

namespace Day4;

public class FileHelper
{
    public static string[] ExtractInputFromFile(string inputFileName)
    {
        var rawInput = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName));

        return rawInput;
    }

    public static IEnumerable<int> ExtractBingoNumbersFromFile(string[] input)
    {
        var firstLine = input[0];

        return firstLine.Split(',').Select(s => Convert.ToInt32(s));
    }

    public static ImmutableList<BingoBoard> ExtractBingoBoardsFromFile(string[] input, int boardHeight, int boardWidth)
    {
        // first row is the called number sequence, drop it
        var trimmedInput = input.Skip(1).ToList();

        var chunkedInput = trimmedInput
            .Chunk(boardHeight)
            .Where(chunk => chunk.Length == boardHeight)
            .Select(strings => strings.Select(s => s.Trim()));

        var convertedBoards = chunkedInput
            .Select(c => c
                .SelectMany(s => s.Split(" ", StringSplitOptions.TrimEntries))
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => Convert.ToInt32(s))
                .Chunk(boardWidth)
                .SelectMany((rowValues, index) => Position.GeneratePositionRow(rowValues, index)))
            .Select(b => new BingoBoard(b.ToList()));
        
        return convertedBoards.ToImmutableList();
    }
}