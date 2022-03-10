// See https://aka.ms/new-console-template for more information

// Part 1

using System.Collections.Immutable;
using Day4;

var rawInput = FileHelper.ExtractInputFromFile("day4input.txt");

var finalGameStep = GameOperations
        .RunGameUntilWin(
                new GameStep(FileHelper.ExtractBingoBoardsFromFile(rawInput, 5, 5),
                    FileHelper.ExtractBingoNumbersFromFile(rawInput).ToImmutableList())
                );

var finalScore = finalGameStep.LastCalledNumber * GameOperations.GetWinningBoards(finalGameStep).Single().TotalUncalledValues;

Console.WriteLine($"Part 1 solution is {finalScore}");