using System.Collections;

namespace Day3;

public static class Calculators
{
    public static int CalculateGammaRate(List<int[]> inputs)
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

        var finalArray = summedArray
            .Select(s => s / inputs.Count)
            .Select(s => Math.Round(s))
            .Select(Convert.ToBoolean)
            .ToArray();

        // dear lord, the yak shaving
        if (BitConverter.IsLittleEndian)
            Array.Reverse(finalArray);
        
        var gammaRate = new BitArray(finalArray).GetIntFromBitArray();

        return gammaRate;
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