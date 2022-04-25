namespace Day9;

public class HeightMap
{
    public readonly IEnumerable<Position> Map;

    public HeightMap(IEnumerable<Position> map)
    {
        Map = map;
    }
}