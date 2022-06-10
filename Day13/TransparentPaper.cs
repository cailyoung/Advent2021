namespace Day13;

public class TransparentPaper
{
    public int DotCount => MarkedDots.Count();
    private readonly IEnumerable<Dot> MarkedDots;

    public TransparentPaper(IEnumerable<Dot> markedDots)
    {
        MarkedDots = markedDots;
    }
    
    public TransparentPaper Fold(int coOrdToFoldAt, Axis axis)
    {
        Func<Dot, Dot> YAxisDotFolder()
        {
            return d => d with { XPosition = d.XPosition / 2 };
        }
        
        Func<Dot, Dot> XAxisDotFolder()
        {
            return d => d with { YPosition = d.YPosition / 2 };
        }

        Func<Dot, bool> YAxisThreshold()
        {
            return d => d.YPosition > coOrdToFoldAt;
        }
        
        Func<Dot, bool> XAxisThreshold()
        {
            return d => d.XPosition > coOrdToFoldAt;
        }

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

