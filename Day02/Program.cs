// See https://aka.ms/new-console-template for more information

using Day2;

var commandList = FileHelper.ListCommandsFromFile(FileHelper.ExtractInputFromFile("day2input.txt"));

var sub = new Submarine();

sub.Part1TakeCommands(commandList);

var part1Answer = sub.GetCurrentDepth() * sub.GetCurrentHorizontalPosition();

// Part 1
Console.WriteLine($"Part 1 - final product is {part1Answer}");

// Part 2

var sub2 = new Submarine();

sub2.Part2TakeCommands(commandList);

var part2Answer = sub2.GetCurrentDepth() * sub2.GetCurrentHorizontalPosition();

Console.WriteLine($"Part 2 - final product is {part2Answer}");
