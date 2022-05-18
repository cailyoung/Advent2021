// See https://aka.ms/new-console-template for more information

// Part 1

using Day11;

var input = FileHelper.ExtractInputFromFile("day11input.txt");

var initialMap = FileHelper.GenerateInitialEnergyMap(input);

var futureState = MapOperations.ProduceFutureStepState(initialMap, 100);

var flashCountInFuturePartOne = futureState.Sum(p => p.FlashCount);

Console.WriteLine($"Part 1 - after 100 steps, {flashCountInFuturePartOne} flashes have occurred");