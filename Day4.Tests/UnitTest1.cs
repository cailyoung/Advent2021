using System;
using System.Collections.Generic;
using System.Linq;
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
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 1));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 8, 2, 23, 4, 24 }, 2));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int> { 21, 9, 14, 16, 7 }, 3));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow(new List<int>{ 6, 10, 3, 18, 5 }, 4));
        expectedBoardOnePositions.AddRange(Position
            .GeneratePositionRow( new List<int> { 1, 12, 20, 15, 19 }, 5));

        var expectedBoardOne = new BingoBoard(expectedBoardOnePositions);

        var actualBoardOne = FileHelper.ExtractBingoBoardsFromFile(testInput, 5, 5).ElementAtOrDefault(0);

        actualBoardOne.Should().BeEquivalentTo(expectedBoardOne);
    }

    [Fact]
    public void WinningBoardHorizontalIsCorrect()
    {
        var positionList = new List<Position>();
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 1, true));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 2));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 3));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 4));
        positionList.AddRange(Position
            .GeneratePositionRow(new List<int>() { 22, 13, 17, 11, 0 }, 5));
        
        var winningBoard = new BingoBoard(positionList);

        winningBoard.IsWinningBoard.Should().BeTrue();
    }
}