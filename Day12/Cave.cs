using System.Diagnostics;

namespace Day12;

[DebuggerDisplay("{Token}, type {CaveType}")]
public record Cave : IComparable<Cave>, IComparable
{
    public CaveType CaveType;
    public string Token;

    public Cave(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("A Cave must have a token with at least one character.");
        }
        Token = token;
        CaveType = token switch
        {
            "start" => CaveType.Start,
            "end" => CaveType.End,
            _ when token.All(char.IsUpper) => CaveType.Big,
            _ when token.All(char.IsLower) => CaveType.Small,
            _ => CaveType.Unknown
        };
    }
    
    // Generated
    public int CompareTo(Cave? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var tokenComparison = string.Compare(Token, other.Token, StringComparison.Ordinal);
        if (tokenComparison != 0) return tokenComparison;
        return CaveType.CompareTo(other.CaveType);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Cave other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Cave)}");
    }
}

public enum CaveType
{
    Unknown,
    Start,
    End,
    Small,
    Big
}