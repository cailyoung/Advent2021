// See https://aka.ms/new-console-template for more information

// Part One

using Day10;

var input = FileHelper.ExtractInputFromFile("day10input.txt");

var corruptedLines = Parsing.FindCorruptLines(input);

var badTokens = corruptedLines
    .Select(Parsing.FindFirstCorruptToken)
    .Select(char.Parse);

var score = Scoring.CalculateSyntaxErrorScoreForTokens(badTokens);

Console.WriteLine($"Part one - total score for corrupted lines is {score}");