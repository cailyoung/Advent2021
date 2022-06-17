using System.Text;

namespace Day13;

public class TransparentPaper
{
    public int DotCount => MarkedDots.Count();
    public readonly IEnumerable<Dot> MarkedDots;
    private int PaperWidth => MarkedDots.Select(d => d.XPosition).Max() + 1;
    private int PaperHeight => MarkedDots.Select(d => d.YPosition).Max() + 1;

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
    
    public override string ToString()
    {
        var sb = new StringBuilder();

        // Performance
        var height = PaperHeight;
        var width = PaperWidth;

        for (int rowIndex = 0; rowIndex < height; rowIndex++)
        {
            var currentRowChars = new char[width];
            
            var currentRowDots = MarkedDots.Where(d => d.YPosition == rowIndex).ToArray();

            for (int columnIndex = 0; columnIndex < width; columnIndex++)
            {
                currentRowChars[columnIndex] = currentRowDots.Any(d => d.XPosition == columnIndex) ? '#' : '.';
            }

            sb.AppendLine(new string(currentRowChars));
        }
        
        return sb.ToString();
    }
}

public enum Axis
{
    X,
    Y
}

