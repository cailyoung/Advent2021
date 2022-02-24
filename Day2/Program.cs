// See https://aka.ms/new-console-template for more information

using Day2;

var commandList = FileHelper.ListCommandsFromFile(FileHelper.ExtractInputFromFile("day2input.txt"));

var sub = new Submarine();

sub.Part1TakeCommands(commandList);

var part1Answer = sub.GetCurrentDepth() * sub.GetCurrentHorizontalPosition();

// Part 1
Console.WriteLine($"Part 1 - final product is {part1Answer}");