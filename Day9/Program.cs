// See https://aka.ms/new-console-template for more information

// Part 1

using Day9;

var input = FileHelper.ExtractInputFromFile("day9input.txt");

var inputMap = FileHelper.GenerateInitialHeightMap(input);

var riskScorePartOne = MapOperations.GetMapRisk(inputMap);

Console.WriteLine($"Part one risk score is {riskScorePartOne}");