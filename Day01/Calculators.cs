namespace Advent2021;

public class Calculators
{
    public static int CountMeasurementIncreases(int[] ints)
    {
        int count = 0;

        for (int i = 0; i < (ints.Length - 1); i++)
        {
            if (ints[i + 1] > ints[i])
            {
                count++;
            }
        }

        return count;
    }

    public static int[] ProduceWindowedSums(int[] inputs, int windowSize)
    {
        var windowSums = new List<int>();

        for (int i = 0; i < (inputs.Length - (windowSize - 1)); i++)
        {
            var windowSum = inputs[i] + inputs[i + 1] + inputs[i + 2];
            windowSums.Add(windowSum);
        }

        return windowSums.ToArray();
    }
}