using System.Collections.Immutable;

namespace Day6;

public class School
{
    public ImmutableList<LanternFish> CurrentFish { get; }
    public ImmutableDictionary<int, int> CurrentFishDict { get;  }
    public long SchoolSize => CurrentFishCount();

    private int CurrentFishCount()
    {
        return CurrentFish.Count;
    }

    public School(ImmutableList<LanternFish> currentFish)
    {
        CurrentFish = currentFish;
        CurrentFishDict = currentFish
            .GroupBy(fish => fish.DaysUntilBirth)
            .Select(fishes => new { Age = fishes.Key, Count = fishes.Count() })
            .ToImmutableDictionary(group => group.Age, group => group.Count);
    }

    public School(IEnumerable<int> fishSizes)
    {
        CurrentFish = fishSizes.Select(s => new LanternFish(s)).ToImmutableList();
        CurrentFishDict = fishSizes.GroupBy(v => v)
            .Select(fishes => new { Age = fishes.Key, Count = fishes.Count() })
            .ToImmutableDictionary(group => group.Age, group => group.Count);
        ;
    }
}