namespace Day9;

public class HeightMap
{
    public readonly Position[] Map;

    public HeightMap(IEnumerable<Position> map)
    {
        Map = map.ToArray();
    }
}