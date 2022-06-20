// See https://aka.ms/new-console-template for more information

using Day14;

var input = FileHelper.ExtractInputFromFile("day14input.txt");

var inputTemplate = FileHelper.GetTemplate(input);
var inputRules = FileHelper.GetInsertionRules(input).ToArray();

var workingChain = new PolymerChain(inputTemplate);
const int roundsToCalculate = 10;

for (int i = 0; i < roundsToCalculate; i++)
{
    workingChain = workingChain.ApplyInsertionRules(inputRules);
}

Console.WriteLine($"Part one - the difference between most common and least common elements is {workingChain.MostCommonElementCount - workingChain.LeastCommonElementCount}");