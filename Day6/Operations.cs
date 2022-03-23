using System.Collections.Immutable;

namespace Day6;

public class Operations
{
    public static School AddADay(School currentSchool)
    {
        var workingSchoolFish = currentSchool.CurrentFish
            .Select(f => new LanternFish(f.DaysUntilBirth - 1))
            .ToImmutableList();
        
        return new School(workingSchoolFish);
    }
}