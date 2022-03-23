using System.Collections.Immutable;

namespace Day6;

public class School
{
    public ImmutableList<LanternFish> CurrentFish { get; }

    public School(ImmutableList<LanternFish> currentFish)
    {
        CurrentFish = currentFish;
    }
}