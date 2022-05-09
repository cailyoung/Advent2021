namespace Day11;

public record Position(int XValue, int YValue, int Energy)
{
    public bool CurrentlyFlashing => Energy > 9;
    public CoOrd CoOrd => new(XValue, YValue);
}

public record CoOrd(int XValue, int YValue);