// See https://aka.ms/new-console-template for more information

// Part 1

using Day3;

var input = FileHelper.ExtractInputFromFile("day3input.txt");

var parsedInput = FileHelper.ParseInput(input).ToList();

var part1Gamma = Calculators.CalculateGammaRate(parsedInput);
var part1Epsilon = Calculators.CalculateEpsilonRate(parsedInput);

var part1PowerConsumption = part1Gamma * part1Epsilon;

Console.WriteLine($"Part 1 power consumption is {part1PowerConsumption}");

// Part 2

var part2Oxygen = Calculators.CalculateOxygenRate(parsedInput);
var part2Co2 = Calculators.CalculateCarbonDioxideRate(parsedInput);

var part2LifeSupportRating = part2Oxygen * part2Co2;

Console.WriteLine($"Part 2 life support rating is {part2LifeSupportRating}");
