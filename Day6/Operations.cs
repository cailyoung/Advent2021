using System.Collections.Immutable;

namespace Day6;

public class Operations
{
    public static School AddADay(School currentSchool)
    {
        return new School(ImmutableList<LanternFish>.Empty);
    }
}