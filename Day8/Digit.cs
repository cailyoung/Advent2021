namespace Day8;

public class Digit
{
    public enum Character
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Unknown
    }

    public readonly Character CurrentCharacter;
    public readonly string OriginalString;

    
    public Digit(string inputCharacters)
    {
        CurrentCharacter = IdentifyCharacter(inputCharacters);
        OriginalString = inputCharacters;
    }

    public Digit(Character character, string originalString)
    {
        CurrentCharacter = character;
        OriginalString = originalString;
    }

    private static Character IdentifyCharacter(string inputCharacters)
    {
        /*
         * '7' == 3 segments
         * '4' == 4 segments
         * '1' == 2 segments
         * '8' == 7 segments
         */

        return inputCharacters.Length switch
        {
            2 => Character.One,
            3 => Character.Seven,
            4 => Character.Four,
            7 => Character.Eight,
            _ => Character.Unknown
        };
    }
}