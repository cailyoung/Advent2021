// See https://aka.ms/new-console-template for more information

// Part 1

using Day8;

var rawInput = FileHelper.ExtractInputFromFile("day8input.txt");

var outputsOnly = rawInput
    .Select(FileHelper.SplitInputLine)
    .Select(r => r.OutputValues)
    .SelectMany(DataRow.SplitDataRowSection);

var partOneCount = DigitAnalyser.CalculateNumberOfUniqueSegmentCountDigits(outputsOnly);

Console.WriteLine($"Part 1 - the number of times 1/4/7/8 appear in the outputs is {partOneCount}");