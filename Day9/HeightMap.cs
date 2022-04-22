namespace Day9;

public class HeightMap
{
    public IEnumerable<Position> Map;

    public HeightMap(IEnumerable<Position> map)
    {
        Map = map;
    }
}