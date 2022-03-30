using System.Collections.Immutable;
using System.Diagnostics;

namespace Day6;

public class Operations
{
    public static School AddADay(School currentSchool)
    {
        var workingSchoolFish = currentSchool.CurrentFish
            .Select(f => new LanternFish(f.DaysUntilBirth - 1)).ToArray();

        var countOfFishToBirth = workingSchoolFish.Count(f => f.DaysUntilBirth < 0);

        var newSchoolFish = workingSchoolFish
            .Where(f => f.DaysUntilBirth >= 0)
            .Concat(Enumerable.Repeat(new LanternFish(), countOfFishToBirth))
            .Concat(Enumerable.Repeat(new LanternFish(6), countOfFishToBirth));

        return new School(newSchoolFish.ToImmutableList());
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