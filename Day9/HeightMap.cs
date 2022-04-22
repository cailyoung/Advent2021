namespace Day9;

public class HeightMap
{
    private IEnumerable<Position> Map;

    public HeightMap(IEnumerable<Position> map)
    {
        Map = map;
    }
}