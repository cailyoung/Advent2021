using System.Collections.Immutable;

namespace Day5;

public class VentLine
{
    public CoOrd Start { get; }
    public CoOrd End { get; }
    public ImmutableList<CoOrd> LineCoOrds => CalculateLineCoOrds();
    public bool Horizontal => Start.YValue == End.YValue;
    public bool Vertical => Start.XValue == End.XValue;
    public bool Diagonal => !Horizontal && !Vertical;
    public SlopeOptions Slope { get; }

    public enum SlopeOptions
    {
        Vertical,
        Horizontal,
        Diagonal,
        Unknown
    }

    private ImmutableList<CoOrd> CalculateLineCoOrds()
    {
        switch (Slope)
        {
            case SlopeOptions.Horizontal:
                return GenerateHorizontalFullCoOrds();
            case SlopeOptions.Vertical:
                return GenerateVerticalFullCoOrds();
            case SlopeOptions.Diagonal:
                return GenerateDiagonalFullCoOrds();
            case SlopeOptions.Unknown:
                throw new ArgumentException("This isn't a diagonal");
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        return ImmutableList<CoOrd>.Empty;
    }

    private ImmutableList<CoOrd> GenerateVerticalFullCoOrds()
    {
        var xValue = Start.XValue;

        var yValues = new List<int>
        {
            Start.YValue,
            End.YValue
        };

        var workingList = Enumerable.Range(yValues.Min(), yValues.Max() - yValues.Min() + 1)
            .Select(yValue => new CoOrd(xValue, yValue))
            .ToImmutableList();

        return workingList;
    }

    private ImmutableList<CoOrd> GenerateHorizontalFullCoOrds()
    {
        var yValue = Start.YValue;

        var xValues = new List<int>
        {
            Start.XValue,
            End.XValue
        };

        var workingList = Enumerable.Range(xValues.Min(), xValues.Max() - xValues.Min() + 1)
            .Select(xValue => new CoOrd(xValue, yValue))
            .ToImmutableList();

        return workingList;
    }
    
    private ImmutableList<CoOrd> GenerateDiagonalFullCoOrds()
    {
        var yValues = new List<int>
        {
            Start.YValue,
            End.YValue
        };

        var xValues = new List<int>
        {
            Start.XValue,
            End.XValue
        };

        var xRange = Enumerable.Range(xValues.Min(), xValues.Max() - xValues.Min() + 1);
        var yRange = Enumerable.Range(yValues.Min(), yValues.Max() - yValues.Min() + 1);

        return xRange.Zip(yRange, (x, y) => new CoOrd(x, y)).ToImmutableList();
    }

    public VentLine(string textCoOrdStart, string textCoOrdEnd)
    {
        Start = new CoOrd(textCoOrdStart);
        End = new CoOrd(textCoOrdEnd);
        Slope = GetSlope();
    }

    private SlopeOptions GetSlope()
    {
        if (Diagonal) return SlopeOptions.Diagonal;
        if (Vertical) return SlopeOptions.Vertical;
        if (Horizontal) return SlopeOptions.Horizontal;
        return SlopeOptions.Unknown;
    }
}