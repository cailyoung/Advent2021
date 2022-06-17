// See https://aka.ms/new-console-template for more information

// Part 1

using Day7;

var rawInput = FileHelper.ExtractInputFromFile("day7input.txt");

var subField = new SubmarineField(rawInput);

var minimumFuelToAlign = subField.CheapestTargetPositionLinearFuelUsed;

Console.WriteLine($"Part 1 = Most fuel efficient position will use {minimumFuelToAlign}");

// Part 2

var minimumFuelPartTwo = subField.CheapestTargetPositionGeometricFuelUsed;

Console.WriteLine($"Part 2 - For nonlinear fuel usage, the cheapest position uses {minimumFuelPartTwo}");