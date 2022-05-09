namespace Day11;

public class EnergyMap
{
    public readonly Position[] Map;

    public EnergyMap(IEnumerable<Position> map)
    {
        Map = map.ToArray();
    }
}