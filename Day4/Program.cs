// See https://aka.ms/new-console-template for more information

// Part 1

using System.Collections.Immutable;
using Day4;

var rawInput = FileHelper.ExtractInputFromFile("day4input.txt");

var startingBoards = FileHelper.ExtractBingoBoardsFromFile(rawInput, 5, 5);
var startingBingoNumbersToCall = FileHelper.ExtractBingoNumbersFromFile(rawInput).ToImmutableList();

var initialGameStep = new GameStep(startingBoards, startingBingoNumbersToCall);

var finalGameStep = GameOperations.RunGameUntilWin(initialGameStep);

var finalScore = finalGameStep.LastCalledNumber * GameOperations.GetWinningBoards(finalGameStep).Single().TotalUncalledValues;

Console.WriteLine($"Part 1 solution is {finalScore}");