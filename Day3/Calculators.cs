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

        var finalArray = AverageValues(inputs.Count, summedArray)
            .EnsureArrayEndianness();
        
        return finalArray;
    }

    private static bool[] EnsureArrayEndianness(this bool[] array)
    {
        // dear lord, the yak shaving
        if (BitConverter.IsLittleEndian)
            Array.Reverse(array);

        return array;
    }

    private static bool[] AverageValues(int length, double[] summedArray)
    {
        return summedArray
            .Select(s => s / length)
            .Select(RoundedColumnValue)
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

    public static int RoundedColumnValue(double columnValue)
    {
        return (int)Math.Round(columnValue, MidpointRounding.AwayFromZero);
    }

    private static int MostCommonBitValueInColumn(IEnumerable<int> columnValues)
    {
        var average = columnValues.Average();

        return RoundedColumnValue(average);
    }

    private static int FilterInputValuesForEnvironmentRatings(List<int[]> inputs, bool findMostCommon = true)
    {
        var listCopy = new List<int[]>(inputs);
        
        var inputLength = listCopy[0].Length;

        for (int i = 0; i < inputLength; i++)
        {
            var columnIndex = i;

            var tempColumn = listCopy.Select(row => row[columnIndex]);

            var mostCommonBitValueInColumn = MostCommonBitValueInColumn(tempColumn);


            switch (findMostCommon)
            {
                case true:
                    listCopy.RemoveAll(s => s[columnIndex] != mostCommonBitValueInColumn);
                    break;
                case false:
                    listCopy.RemoveAll(s => s[columnIndex] == mostCommonBitValueInColumn);
                    break;
            }
            
            if (listCopy.Count == 1) 
                break;
        }

        var finalValueBools = listCopy
            .Single()
            .Select(Convert.ToBoolean)
            .ToArray()
            .EnsureArrayEndianness();

        return new BitArray(finalValueBools).GetIntFromBitArray();
    }
    public static int CalculateOxygenRate(List<int[]> inputs)
    {
        return FilterInputValuesForEnvironmentRatings(inputs);
    }

    public static int CalculateCarbonDioxideRate(List<int[]> inputs)
    {
        return FilterInputValuesForEnvironmentRatings(inputs, false);
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