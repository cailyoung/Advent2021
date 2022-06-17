namespace Day13;

public class TransparentPaper
{
    public int DotCount => MarkedDots.Count();
    public readonly IEnumerable<Dot> MarkedDots;

    public TransparentPaper(IEnumerable<Dot> markedDots)
    {
        MarkedDots = markedDots;
    }
    
    public TransparentPaper Fold(int coOrdToFoldAt, Axis axis)
    {
        Func<Dot, Dot> YAxisDotFolder() => d => d with { YPosition = coOrdToFoldAt - Math.Abs(d.YPosition - coOrdToFoldAt) };

        Func<Dot, Dot> XAxisDotFolder() => d => d with { XPosition = coOrdToFoldAt - Math.Abs(d.XPosition - coOrdToFoldAt) };

        Func<Dot, bool> YAxisThreshold() => d => d.YPosition > coOrdToFoldAt;

        Func<Dot, bool> XAxisThreshold() => d => d.XPosition > coOrdToFoldAt;

        var dotIsOverAxisThreshold = axis == Axis.X ? XAxisThreshold() : YAxisThreshold();

        var foldedDot = axis == Axis.X ? XAxisDotFolder() : YAxisDotFolder();

        var dotsToFold = MarkedDots.Where(dotIsOverAxisThreshold).ToArray();

        var foldedDots = dotsToFold.Select(foldedDot);

        return new TransparentPaper(MarkedDots.Except(dotsToFold).Union(foldedDots));
    }
}

public enum Axis
{
    X,
    Y
}

