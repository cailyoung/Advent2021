using System.Collections.Immutable;

namespace Day6;

public class School
{
    private ImmutableList<LanternFish> CurrentFish;

    public School(ImmutableList<LanternFish> currentFish)
    {
        CurrentFish = currentFish;
    }
}