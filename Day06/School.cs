using System.Collections.Immutable;

namespace Day6;

public class School
{
    public ImmutableDictionary<int, long> CurrentFishDict { get;  }
    public long SchoolSize => CurrentFishCount();

    private long CurrentFishCount()
    {
        return CurrentFishDict.Select(v => v.Value).Sum();
    }

    public School(ImmutableList<LanternFish> currentFish)
    {
        CurrentFishDict = currentFish
            .GroupBy(fish => fish.DaysUntilBirth)
            .Select(fishes => new { Age = fishes.Key, Count = fishes.Count() })
            .ToImmutableDictionary(group => group.Age, group => (long)group.Count);
    }

    public School(IEnumerable<int> fishSizes)
    {
        CurrentFishDict = fishSizes.GroupBy(v => v)
            .Select(fishes => new { Age = fishes.Key, Count = fishes.Count() })
            .ToImmutableDictionary(group => group.Age, group => (long)group.Count);
    }

    public School(ImmutableDictionary<int, long> fishDict)
    {
        CurrentFishDict = fishDict;
    }
}