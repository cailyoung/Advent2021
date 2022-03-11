using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using FluentAssertions;
using Xunit;

namespace Day4.Tests;

public class UnitTest1
{
    [Fact]
    public void InputParserCanExtractBingoNumbersCorrectly()
    {
        var testInput = @"
7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var expectedOutput = new[]
        {
            7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1
        };

        FileHelper.ExtractBingoNumbersFromFile(testInput).Should().BeEquivalentTo(expectedOutput);
    }

    [Fact]
    public void InputParserCanExtractBingoBoardsCorrectly()
    {
        var testInput = @"
7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var expectedBoardOnePositions = new List<Position>();

        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 22, 13, 17, 11, 0 }, 0));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 8, 2, 23, 4, 24 }, 1));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 21, 9, 14, 16, 7 }, 2));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 6, 10, 3, 18, 5 }, 3));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 1, 12, 20, 15, 19 }, 4));

        var expectedBoardOne = new BingoBoard(expectedBoardOnePositions);

        var actualBoardOne = FileHelper.ExtractBingoBoardsFromFile(testInput, 5, 5).ElementAtOrDefault(0);

        actualBoardOne.Should().BeEquivalentTo(expectedBoardOne);
    }

    [Fact]
    public void WinningBoardHorizontalIsCorrect()
    {
        var positionList = new List<Position>();
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 0, true));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 1));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 2));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 3));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 4));
        
        var winningBoard = new BingoBoard(positionList);

        winningBoard.IsWinningBoard.Should().BeTrue();
    }
    [Fact]
    public void WinningBoardVerticalIsCorrect()
    {
        var positionList = new List<Position>
        {
            new(0, 0, 0, true),
            new(0, 1, 0, true),
            new(0, 2, 0, true),
            new(0, 3, 0, true),
            new(0, 4, 0, true),
            new(1, 0, 0),
            new(1, 1, 0),
            new(1, 2, 0),
            new(1, 3, 0),
            new(1, 4, 0),
            new(2, 0, 0),
            new(2, 1, 0),
            new(2, 2, 0),
            new(2, 3, 0),
            new(2, 4, 0),
            new(3, 0, 0),
            new(3, 1, 0),
            new(3, 2, 0),
            new(3, 3, 0),
            new(3, 4, 0),
            new(4, 0, 0),
            new(4, 1, 0),
            new(4, 2, 0),
            new(4, 3, 0),
            new(4, 4, 0)
        };

        var winningBoard = new BingoBoard(positionList);

        winningBoard.IsWinningBoard.Should().BeTrue();
    }
    
    [Fact]
    public void WinningBoardVerticalAndHorizontalIsCorrect()
    {
        var positionList = new List<Position>
        {
            new(0, 0, 0, true),
            new(0, 1, 0, true),
            new(0, 2, 0, true),
            new(0, 3, 0, true),
            new(0, 4, 0, true),
            new(1, 0, 0, true),
            new(1, 1, 0),
            new(1, 2, 0),
            new(1, 3, 0),
            new(1, 4, 0),
            new(2, 0, 0, true),
            new(2, 1, 0),
            new(2, 2, 0),
            new(2, 3, 0),
            new(2, 4, 0),
            new(3, 0, 0, true),
            new(3, 1, 0),
            new(3, 2, 0),
            new(3, 3, 0),
            new(3, 4, 0),
            new(4, 0, 0, true),
            new(4, 1, 0),
            new(4, 2, 0),
            new(4, 3, 0),
            new(4, 4, 0)
        };

        var winningBoard = new BingoBoard(positionList);

        winningBoard.IsWinningBoard.Should().BeTrue();
    }

    [Fact]
    public void CallingFirstNumberAppliesCorrectly()
    {
        var positionListOne = new List<Position>();
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 0));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 8, 2, 23, 4, 24 }, 1));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 21, 9, 14, 16, 7 }, 2));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 6, 10, 3, 18, 5 }, 3));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 1, 12, 20, 15, 19 }, 4));
        
        var boardOne = new BingoBoard(positionListOne);
        
        var positionListTwo = new List<Position>();
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 3, 15, 0, 2, 22 }, 0));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 9, 18, 13, 17, 5 }, 1));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 19, 8, 7, 25, 23 }, 2));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 20, 11, 10, 24, 4 }, 3));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 14, 21, 16, 12, 6 }, 4));
        
        var boardTwo = new BingoBoard(positionListTwo);
        
        var positionListThree = new List<Position>();
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 14, 21, 17, 24, 4 }, 0));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 10, 16, 15, 9, 19 }, 1));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 18, 8, 23, 26, 20 }, 2));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 11, 13, 6, 5 }, 3));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 2, 0, 12, 3, 7 }, 4));
        
        var boardThree = new BingoBoard(positionListThree);

        var initialBoardList = ImmutableList.Create(boardOne, boardTwo, boardThree);
        var initialNumbersToCall = new[]
        {
            7, 4, 9, 5, 11
        };
        var previousStep = new GameStep(initialBoardList, initialNumbersToCall.ToImmutableList());

        var nextStep = GameOperations.CallNextBingoNumber(previousStep);

        var calledCount = nextStep.Boards.SelectMany(board => board.CalledPositions()).Count();
        var calledViolations = nextStep.Boards.SelectMany(board => board.CalledPositions())
            .Where(position => position.Value != initialNumbersToCall.First());
        
        Assert.Equal(3, calledCount);
        Assert.Empty(calledViolations);
    }
    
    [Fact]
    public void CallingFirstNumberRemovesItFromTheList()
    {
        var positionListOne = new List<Position>();
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 0));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 8, 2, 23, 4, 24 }, 1));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 21, 9, 14, 16, 7 }, 2));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 6, 10, 3, 18, 5 }, 3));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 1, 12, 20, 15, 19 }, 4));
        
        var boardOne = new BingoBoard(positionListOne);
        
        var initialBoardList = ImmutableList.Create(boardOne);
        var initialNumbersToCall = new[]
        {
            7, 4, 9, 5, 11
        };

        var expectedNumbersToCallNext = new[]
        {
            4, 9, 5, 11
        };
        var previousStep = new GameStep(initialBoardList, initialNumbersToCall.ToImmutableList());

        var nextStep = GameOperations.CallNextBingoNumber(previousStep);

        nextStep.BingoNumbersToCall.Should().BeEquivalentTo(expectedNumbersToCallNext);
    }

    [Fact]
    public void RunningGameProducesExpectedLastNumber()
    {
                var positionListOne = new List<Position>();
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 0));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 8, 2, 23, 4, 24 }, 1));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 21, 9, 14, 16, 7 }, 2));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 6, 10, 3, 18, 5 }, 3));
        positionListOne.AddRange(Position
            .GeneratePositionRow(new List<int>() { 1, 12, 20, 15, 19 }, 4));
        
        var boardOne = new BingoBoard(positionListOne);
        
        var positionListTwo = new List<Position>();
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 3, 15, 0, 2, 22 }, 0));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 9, 18, 13, 17, 5 }, 1));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 19, 8, 7, 25, 23 }, 2));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 20, 11, 10, 24, 4 }, 3));
        positionListTwo.AddRange(Position
            .GeneratePositionRow(new List<int>() { 14, 21, 16, 12, 6 }, 4));
        
        var boardTwo = new BingoBoard(positionListTwo);
        
        var positionListThree = new List<Position>();
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 14, 21, 17, 24, 4 }, 0));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 10, 16, 15, 9, 19 }, 1));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 18, 8, 23, 26, 20 }, 2));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 11, 13, 6, 5 }, 3));
        positionListThree.AddRange(Position
            .GeneratePositionRow(new List<int>() { 2, 0, 12, 3, 7 }, 4));
        
        var boardThree = new BingoBoard(positionListThree);

        var initialBoardList = ImmutableList.Create(boardOne, boardTwo, boardThree);
        var initialNumbersToCall = new[]
        {
            7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1
        };
        var initialStep = new GameStep(initialBoardList, initialNumbersToCall.ToImmutableList());

        var finalState = GameOperations.RunGameUntilWin(initialStep);
        var finalCalledNumber = finalState.LastCalledNumber;
        
        Assert.Equal(24, finalCalledNumber);

        var winningBoard = GameOperations.GetWinningBoards(finalState).Single();

        var totalUncalledValuesFromWinningBoard = winningBoard.TotalUncalledValues;
        
        Assert.Equal(188, totalUncalledValuesFromWinningBoard);
        
        Assert.Equal(4512, totalUncalledValuesFromWinningBoard * finalCalledNumber);
    }

    [Fact]
    public void FullInputIsParsedCorrectly()
    {
        var rawInput = FileHelper.ExtractInputFromFile("../../../../Day4/bin/Debug/net6.0/day4input.txt");
        
        var startingBoards = FileHelper.ExtractBingoBoardsFromFile(rawInput, 5, 5);

        var calledPositionViolations = startingBoards.Select(board => board.CalledPositions().Count).Any(s => s != 0);
        
        Assert.False(calledPositionViolations);
        
        var uncalledPositionViolations = startingBoards.Select(board => board.UnCalledPositions().Count).Any(s => s != 25);
        
        Assert.False(uncalledPositionViolations);

    }
}