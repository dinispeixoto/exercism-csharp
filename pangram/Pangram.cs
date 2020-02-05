using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input) => 
        Enumerable.Range('a', 'z' - 'a' + 1).All(c => input.ToLower().Contains((char)c));
}
