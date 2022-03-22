// See https://aka.ms/new-console-template for more information

// Part 1

using Day5;

var rawInput = FileHelper.ExtractInputFromFile("day5input.txt");

var parsedInput = FileHelper
    .ExtractVentLinesFromFile(rawInput)
    .Where(line => !line.Diagonal);

var mapGrid = new MapGrid(parsedInput);

var overlaps = Calculators.Overlaps(mapGrid);

var atLeastTwoOverlapsCount = overlaps.Count(p => p.overlapCount >= 2);

Console.WriteLine($"For the full input, the number of points where at least two lines overlap is {atLeastTwoOverlapsCount}");