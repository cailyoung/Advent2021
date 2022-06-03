// See https://aka.ms/new-console-template for more information

// Part one

using Day12;

var input = FileHelper.ExtractInputFromFile("day12input.txt");

var caveSystem = FileHelper.ParseInput(input);

var pathCount = caveSystem.ValidPartOnePaths;
var pathCountTwo = caveSystem.ValidPartTwoPaths;

Console.WriteLine($"Part 1 = the cave has {pathCount} paths through it that visit a small cave only once");

Console.WriteLine($"Part 1 = the cave has {pathCountTwo} paths through it that visit a small cave only once");