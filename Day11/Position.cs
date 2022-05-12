namespace Day11;

public record Position(int XValue, int YValue, int Energy)
{
    public bool CurrentlyFlashing => Energy > 9;
    public CoOrd CoOrd => new(XValue, YValue);

    public virtual bool Equals(Position? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return XValue == other.XValue && YValue == other.YValue;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(XValue, YValue);
    }
}

public record CoOrd(int XValue, int YValue);