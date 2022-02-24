namespace Advent2021;

public class DepthCalculators
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
}