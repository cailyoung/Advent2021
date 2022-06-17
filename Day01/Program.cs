// See https://aka.ms/new-console-template for more information

using Advent2021;

var inputNumbers = FileHelper.ExtractInputFromFile("day1input.txt");

var countOfDepthIncreases = Calculators.CountMeasurementIncreases(inputNumbers);

// Day 1 Part 1

Console.WriteLine($"For the input, the number of measurements larger than the previous measurement is {countOfDepthIncreases}.");

// Day 1 Part 2

var windowSums = Calculators.ProduceWindowedSums(inputNumbers, 3);

var countOfWindowedDepthIncreases = Calculators.CountMeasurementIncreases(windowSums.ToArray());

Console.WriteLine($"For the input, the number of windowed measurements larger than the previous windowed measurement is {countOfWindowedDepthIncreases}.");