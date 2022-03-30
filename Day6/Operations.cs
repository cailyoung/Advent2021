using System.Collections.Immutable;
using System.Diagnostics;

namespace Day6;

public class Operations
{
    private const int AgeToGiveBirth = 0;
    private const int NewAgeForNewFishAtBirth = 8;
    private const int NewAgeForOldFishAtBirth = 6;
    
    public static School AddADay(School currentSchool)
    {
        var workingDict = currentSchool.CurrentFishDict;

        // https://stackoverflow.com/a/25127601/16498827
        long numberOfFishToAdd = workingDict.TryGetValue(AgeToGiveBirth, out numberOfFishToAdd) ? numberOfFishToAdd : 0;

        var agedDict = workingDict
            .ToList()
            .Select(pair => new { Age = pair.Key - 1, Count = pair.Value })
            .Where(pair => pair.Age >= AgeToGiveBirth)
            .ToDictionary(pair => pair.Age, pair => pair.Count);

        if (numberOfFishToAdd > 0)
        {
        
            if (agedDict.ContainsKey(NewAgeForOldFishAtBirth))
            {
                agedDict[NewAgeForOldFishAtBirth] += numberOfFishToAdd;
            }
            else
            {
                agedDict.Add(NewAgeForOldFishAtBirth, numberOfFishToAdd);
            }
            
            agedDict.Add(NewAgeForNewFishAtBirth, numberOfFishToAdd);
        }
        
        return new School(agedDict.ToImmutableDictionary());
    }

    public static School RunSimulation(School initialSchool, int daysToSimulate)
    {
        var workingSchool = new School(initialSchool.CurrentFishDict);

        var stopwatch = new Stopwatch();
        
        for (int i = 0; i < daysToSimulate; i++)
        {
            stopwatch.Start();
            workingSchool = AddADay(workingSchool);
            Console.WriteLine($"Iteration {i}, elapsed time {stopwatch.Elapsed.TotalMilliseconds}");
            stopwatch.Stop();
            stopwatch.Reset();
        }

        return workingSchool;
    }
}