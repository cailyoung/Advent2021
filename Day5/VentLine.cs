using System.Collections.Immutable;

namespace Day5;

public class VentLine
{
    public CoOrd Start { get; }
    public CoOrd End { get; }
    public ImmutableList<CoOrd> LineCoOrds => CalculateLineCoOrds();
    public bool Horizontal => Start.YValue == End.YValue;
    public bool Vertical => Start.XValue == End.XValue;
    private ImmutableList<CoOrd> CalculateLineCoOrds()
    {
        if (!Horizontal && !Vertical)
        {
            // not in spec (yet?)
            return ImmutableList<CoOrd>.Empty;
        }

        if (Horizontal)
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

        if (Vertical)
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
        
        return ImmutableList<CoOrd>.Empty;
    }

    public VentLine(string textCoOrdStart, string textCoOrdEnd)
    {
        Start = new CoOrd(textCoOrdStart);
        End = new CoOrd(textCoOrdEnd);
    }
}