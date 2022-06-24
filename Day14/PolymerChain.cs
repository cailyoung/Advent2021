namespace Day14;

public class PolymerChain
{
    public readonly string ChainString;
    public int ChainLength => ChainString.Length;
    public long MostCommonElementCount => GetMostCommonElementCount();
    public long LeastCommonElementCount => GetLeastCommonElementCount();

    public PolymerChain(string template)
    {
        ChainString = template;
    }

    public PolymerChain ApplyInsertionRules(PairInsertionRule[] rules)
    {
        // get a (queue?) of the chars in the current string
        var workingElementQueue = GetQueueFromString(ChainString);
        Console.WriteLine($"Updating Element Queue, current length {ChainLength}");

        // process the queue, passing in insertion rules
        var updatedQueue = UpdateElementsAccordingToRules(workingElementQueue, rules);
        
        //TODO try out Dataflow blocks????
        
        // convert the new queue into a new polymerchain and return it
        return new PolymerChain(string.Concat(updatedQueue));
    }

    private static IEnumerable<char> UpdateElementsAccordingToRules(Queue<char> elementsToProcess, PairInsertionRule[] rules)
    {
        // generate array of pairs
        // generate array of mutated pairs
        // sew together mutated pairs

        var arrayOfPairs = elementsToProcess
            .Zip(elementsToProcess.Skip(1))
            .Select(p => string.Concat(new[]{ p.First, p.Second} ))
            .ToArray();

        var arrayOfMutatedPairs = arrayOfPairs.Select(s => ApplyMutationRules(s, rules)).ToArray();

        var mergedFinalPairs = MergeMutatedPairs(arrayOfMutatedPairs);

        return mergedFinalPairs;
    }

    private static char[] MergeMutatedPairs(string[] arrayOfMutatedPairs)
    {
        var finalList = new List<char>(arrayOfMutatedPairs.Length * 3);

        var workingQueue = new Queue<string>(arrayOfMutatedPairs);

        while (workingQueue.Count > 1)
        {
            var pairToAssess = workingQueue.Dequeue().ToCharArray();
            var pairToAppend = pairToAssess.SkipLast(1).ToArray();
            finalList.AddRange(pairToAppend);
        }
        
        // put final mutated pair in, complete
        finalList.AddRange(workingQueue.Dequeue().ToCharArray());

        return finalList.ToArray();
    }

    private static string ApplyMutationRules(string tokenPair, PairInsertionRule[] rules)
    {
        switch (rules.Any(r => r.PairToMatch == tokenPair))
        {
            case true:
                var rule = rules.First(r => r.PairToMatch == tokenPair);
                return string.Concat(new[] {tokenPair.ToCharArray()[0], rule.CharToInsert, tokenPair.ToCharArray()[1]});
            case false:
                return tokenPair;
        }
    }


    private static Queue<char> GetQueueFromString(string chainString)
    {
        return new Queue<char>(chainString.ToCharArray());
    }

    private long GetMostCommonElementCount()
    {
        return ChainString
            .ToCharArray()
            .GroupBy(c => c)
            .OrderByDescending(group => (long)group.Count())
            .First().Count();
    }
    
    private long GetLeastCommonElementCount()
    {
        return ChainString
            .ToCharArray()
            .GroupBy(c => c)
            .OrderBy(group => (long)group.Count())
            .First().Count();
    }
}