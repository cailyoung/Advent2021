using System.Collections.Immutable;

namespace Day6;

public class Operations
{
    public static School AddADay(School currentSchool)
    {
        var workingSchoolFish = currentSchool.CurrentFish
            .Select(f => new LanternFish(f.DaysUntilBirth - 1)).ToList();

        var countOfFishToBirth = workingSchoolFish.Count(f => f.DaysUntilBirth < 0);

        workingSchoolFish.RemoveAll(f => f.DaysUntilBirth < 0);
        
        workingSchoolFish.AddRange(Enumerable.Repeat(new LanternFish(), countOfFishToBirth));
        workingSchoolFish.AddRange(Enumerable.Repeat(new LanternFish(6), countOfFishToBirth));
        
        return new School(workingSchoolFish.ToImmutableList());
    }
}