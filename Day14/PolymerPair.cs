namespace Day14;

public class PolymerPair
{
    public PolymerPair(char left, char right)
    {
        Left = left;
        Right = right;
    }

    public char Left { get; }
    public char Right { get; }

    public override string ToString()
    {
        return string.Concat(Left, Right);
    }
}