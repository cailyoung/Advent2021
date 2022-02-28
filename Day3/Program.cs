// See https://aka.ms/new-console-template for more information

// Part 1

using Day3;

var input = FileHelper.ExtractInputFromFile("day3input.txt");

var parsedInput = FileHelper.ParseInput(input).ToList();

var part1Gamma = Calculators.CalculateGammaRate(parsedInput);
var part1Epsilon = Calculators.CalculateEpsilonRate(parsedInput);

var part1PowerConsumption = part1Gamma * part1Epsilon;

Console.WriteLine($"Part 1 power consumption is {part1PowerConsumption}");