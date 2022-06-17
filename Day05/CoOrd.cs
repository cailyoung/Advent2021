namespace Day5;

public class CoOrd
{
    public int XValue { get; }
    public int YValue { get; }
    public (int XValue, int YValue) CompoundCoordinate => new(XValue, YValue);
    public CoOrd(string textCoOrd)
    {
        XValue = Convert.ToInt32(textCoOrd.Split(",").First());
        YValue = Convert.ToInt32(textCoOrd.Split(",").Reverse().First());
    }

    public CoOrd(int xValue, int yValue)
    {
        XValue = xValue;
        YValue = yValue;
    }
}