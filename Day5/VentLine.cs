using System.Collections.Immutable;
using System.Linq.Expressions;

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
        return Slope switch
        {
            SlopeOptions.Horizontal => GenerateHorizontalFullCoOrds(),
            SlopeOptions.Vertical => GenerateVerticalFullCoOrds(),
            SlopeOptions.Diagonal => GenerateDiagonalFullCoOrds(),
            SlopeOptions.Unknown => throw new ArgumentException("This isn't a diagonal"),
            _ => throw new ArgumentOutOfRangeException()
        };
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

        var xRange = GetSortedValuesRange(xValues, Start.XValue < End.XValue);
        var yRange = GetSortedValuesRange(yValues, Start.YValue < End.YValue);

        return xRange.Zip(yRange, (x, y) => new CoOrd(x, y)).ToImmutableList();
    }

    private static IEnumerable<int> GetSortedValuesRange(List<int> values, bool ascending)
    {
        return ascending switch
        {
            true => Enumerable.Range(values.First(), values.Max() - values.Min() + 1),
            false => Enumerable.Range(values.Min(), values.Max() - values.Min() + 1).Reverse()
        };
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