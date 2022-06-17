namespace Day14;

public class PolymerChain
{
    private readonly IEnumerable<PolymerPair> ElementChain;
    public string ChainString => GetChainString();

    public PolymerChain(string template)
    {
        ElementChain = CreatePairChainFromTemplate(template);
    }

    private static IEnumerable<PolymerPair> CreatePairChainFromTemplate(string template)
    {
        return template
            .Zip(template.Skip(1))
            .Select(tuple => new PolymerPair(tuple.First, tuple.Second));
    }

    public PolymerChain ApplyInsertionRules(IEnumerable<PairInsertionRule> rules)
    {
        // get all the pairs
        // for each pair, get back a new string with its insertion (or original if no matching rule)
        // concat all the strings - this isn't working because need to dedupe somehow :(
        // return a new chain based on the concats - see above, not working
        
        // plan B
        // get the chainstring
        // ??? match pairs and string positions?
        // generate insertion instructions that specify positions to insert at
        
        // plan c
        // walk the chainstring with a windowed search

        var pairsWithRulesApplied = ApplyRulesToPairs(ElementChain, rules);

        return new PolymerChain(string.Concat(pairsWithRulesApplied));
    }

    private static IEnumerable<string> ApplyRulesToPairs(IEnumerable<PolymerPair> elementChain, IEnumerable<PairInsertionRule> rules)
    {
        return elementChain.Select(pair => ApplyRulesToPair(pair, rules));
    }

    private static string ApplyRulesToPair(PolymerPair pair, IEnumerable<PairInsertionRule> rules)
    {
        var matchingRules = rules
            .Where(r => r.PairToMatch == pair.ToString())
            .ToArray();

        return matchingRules.Any() switch
        {
            false => pair.ToString(),
            true => string.Concat(pair.Left, matchingRules.Single().CharToInsert, pair.Right)
        };
    }


    private string GetChainString()
    {
        return string.Concat(
            string.Concat(ElementChain.SkipLast(1).Select(p => p.Left)),
            ElementChain.Last().ToString()
        );
    }
}