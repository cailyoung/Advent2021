// See https://aka.ms/new-console-template for more information

// Part 1

using Day8;

var rawInput = FileHelper.ExtractInputFromFile("day8input.txt");

var outputsOnly = rawInput
    .Select(FileHelper.SplitInputLine)
    .SelectMany(dr => dr.GetInputDigits());

var partOneCount = DigitAnalyser.CalculateNumberOfUniqueSegmentCountDigits(outputsOnly);

Console.WriteLine($"Part 1 - the number of times 1/4/7/8 appear in the outputs is {partOneCount}");

// Part 2

var dataRows = rawInput
    .Select(FileHelper.SplitInputLine)
    .ToList();
    
var partTwoCount = DataRow.GenerateMappedDataRows(dataRows)
    .Select(dr => dr.GetOutputDigits())
    .Select(DataRow.GenerateOutputSectionNumber)
    .Sum();
    
Console.WriteLine($"Part 2 - after decoding, the sum of all output digits is {partTwoCount}");