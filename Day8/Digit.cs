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

    public Character CurrentCharacter;

    
    public Digit(string inputCharacters)
    {
        CurrentCharacter = IdentifyCharacter(inputCharacters);
    }

    private Character IdentifyCharacter(string inputCharacters)
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