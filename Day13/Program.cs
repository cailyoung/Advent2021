// See https://aka.ms/new-console-template for more information

// Part 1

using Day13;

var input = FileHelper.ExtractInputFromFile("day13input.txt");

var inputPaper = new TransparentPaper(FileHelper.GetDots(input));

var inputFolds = FileHelper.GetFolds(FileHelper.ExtractInputFromFile("day13folds.txt"));

var firstFold = inputFolds.First();

var firstFoldedPaper = inputPaper.Fold(firstFold);

Console.WriteLine($"Part one - after the first fold, there are {firstFoldedPaper.DotCount} dots");