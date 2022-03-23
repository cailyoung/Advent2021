using System.Collections.Immutable;

namespace Day6;

public class School
{
    public ImmutableList<LanternFish> CurrentFish { get; }
    public long SchoolSize => CurrentFish.Count;

    public School(ImmutableList<LanternFish> currentFish)
    {
        CurrentFish = currentFish;
    }

    public School(IEnumerable<int> fishSizes)
    {
        CurrentFish = fishSizes.Select(s => new LanternFish(s)).ToImmutableList();
    }
}