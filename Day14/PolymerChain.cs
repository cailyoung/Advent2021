namespace Day14;

public class PolymerChain
{
    public readonly string ChainString;

    public PolymerChain(string template)
    {
        ChainString = template;
    }

    public PolymerChain ApplyInsertionRules(IEnumerable<PairInsertionRule> rules)
    {
        // get a (queue?) of the chars in the current string
        var workingElementQueue = GetQueueFromString(ChainString);
        
        // process the queue, passing in insertion rules
        var updatedQueue = UpdateElementsAccordingToRules(workingElementQueue, rules);
        
        // convert the new queue into a new polymerchain and return it
        return new PolymerChain(string.Concat(updatedQueue));
    }

    private IEnumerable<char> UpdateElementsAccordingToRules(Queue<char> elementsToProcess, IEnumerable<PairInsertionRule> rules)
    {
        var finalElements = new List<char>();
        var workingRules = rules.ToArray();
        
        if (elementsToProcess.Count < 2)
        {
            throw new ArgumentException("There needs to be at least two characters in an element template to assess it for insertion rules.");
        }
        
        // Populate first pair
        var workingElements = new List<char>
        {
            elementsToProcess.Dequeue(),
            elementsToProcess.Dequeue()
        };

        workingElements = ApplyRulesAndRotateElements(workingElements, workingRules, finalElements);

        while (elementsToProcess.Any())
        {
            workingElements.Add(elementsToProcess.Dequeue());
            
            workingElements = ApplyRulesAndRotateElements(workingElements, workingRules, finalElements);

            // Last time through, put the closing element in
            if (!elementsToProcess.Any())
            {
                finalElements.AddRange(workingElements);
            }
        }

        return finalElements;
    }

    private List<char> ApplyRulesAndRotateElements(List<char> workingElements, PairInsertionRule[] workingRules, List<char> finalElements)
    {
        workingElements = ApplyRulesToSinglePair(workingElements, workingRules);
        finalElements.AddRange(GetElementsToAddToFinal(workingElements));
        workingElements = TrimWorkingElements(workingElements);
        return workingElements;
    }

    private static List<char> TrimWorkingElements(IEnumerable<char> workingElements)
    {
        return workingElements.TakeLast(1).ToList();
    }

    private static IEnumerable<char> GetElementsToAddToFinal(IEnumerable<char> workingElements)
    {
        return workingElements.SkipLast(1);
    }

    private List<char> ApplyRulesToSinglePair(List<char> workingElements, IEnumerable<PairInsertionRule> rules)
    {
        var anyMatchingRule = rules.Any(r => r.PairToMatch == string.Concat(workingElements));
        var matchingRule = rules.Single(r => r.PairToMatch == string.Concat(workingElements));

        return anyMatchingRule switch
        {
            true => new List<char> { workingElements.First(), char.Parse(matchingRule.CharToInsert), workingElements.Last() },
            false => workingElements
        };
    }

    private static Queue<char> GetQueueFromString(string chainString)
    {
        return new Queue<char>(chainString.ToCharArray());
    }
}