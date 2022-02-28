using System.Collections;

namespace Day3;

public static class Calculators
{
    public static int CalculateGammaRate(List<int[]> inputs)
    {
        var finalArray = GenerateAveragedArray(inputs);

        var gammaRate = new BitArray(finalArray).GetIntFromBitArray();

        return gammaRate;
    }

    public static int CalculateEpsilonRate(List<int[]> inputs)
    {
        var initialArray = GenerateAveragedArray(inputs);

        var flippedArray = initialArray.Select(s => !s).ToArray();

        var epsilonRate = new BitArray(flippedArray).GetIntFromBitArray();
        
        return epsilonRate;
    }

    private static bool[] GenerateAveragedArray(List<int[]> inputs)
    {
        var summedArray = SumInputPositions(inputs);

        var finalArray = AverageValues(inputs.Count, summedArray);

        // dear lord, the yak shaving
        if (BitConverter.IsLittleEndian)
            Array.Reverse(finalArray);
        return finalArray;
    }

    private static bool[] AverageValues(int length, double[] summedArray)
    {
        return summedArray
            .Select(s => s / length)
            .Select(s => Math.Round(s))
            .Select(Convert.ToBoolean)
            .ToArray();
    }

    private static double[] SumInputPositions(List<int[]> inputs)
    {
        var summedArray = new double[inputs[0].Length];

        foreach (var row in inputs)
        {
            var rowIndex = 0;

            foreach (var positionValue in row)
            {
                summedArray[rowIndex] += positionValue;
                rowIndex++;
            }
        }

        return summedArray;
    }

    public static int CalculateOxygenRate(List<int[]> inputs)
    {
        throw new NotImplementedException();
    }
}

// https://stackoverflow.com/a/11920783/16498827
public static class BinaryConverter
{
    public static int GetIntFromBitArray(this BitArray bitArray)
    {
        int value = 0;

        for (int i = 0; i < bitArray.Count; i++)
        {
            if (bitArray[i])
                value += Convert.ToInt16(Math.Pow(2, i));
        }

        return value;
    }
}