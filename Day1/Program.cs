// See https://aka.ms/new-console-template for more information

using Advent2021;

var inputNumbers = FileHelper.ExtractInputFromFile("day1input.txt");

var countOfDepthIncreases = DepthCalculators.CountMeasurementIncreases(inputNumbers);

// Day 1 Part 1

Console.WriteLine($"For the input, the number of measurements larger than the previous measurement is {countOfDepthIncreases}.");

// Day 1 Part 2

var windowSums = new List<int>();

for (int i = 0; i < (inputNumbers.Length - 2); i++)
{
    var windowSum = inputNumbers[i] + inputNumbers[i + 1] + inputNumbers[i + 2];
    windowSums.Add(windowSum);
}

var countOfWindowedDepthIncreases = DepthCalculators.CountMeasurementIncreases(windowSums.ToArray());

Console.WriteLine($"For the input, the number of windowed measurements larger than the previous windowed measurement is {countOfWindowedDepthIncreases}.");