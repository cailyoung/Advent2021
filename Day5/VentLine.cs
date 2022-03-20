namespace Day5;

public class VentLine
{
    public CoOrd Start { get; }
    public CoOrd End { get; }

    public VentLine(string textCoOrdStart, string textCoOrdEnd)
    {
        Start = new CoOrd(textCoOrdStart);
        End = new CoOrd(textCoOrdEnd);
    }
}