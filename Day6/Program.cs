﻿// See https://aka.ms/new-console-template for more information


// Part 1

using Day6;

var input = FileHelper.ExtractInputFromFile("day6input.txt");

var initialSchool = new School(input);

var dayEightyCount = Operations.RunSimulation(initialSchool, 80).SchoolSize;

Console.WriteLine($"Part 1 - After 80 days, there are {dayEightyCount} fish.");