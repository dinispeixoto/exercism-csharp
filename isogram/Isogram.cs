using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var sortedString = String.Concat(word.Where(char.IsLetterOrDigit).OrderBy(c => c)).ToLower();

        for(var i = 0; i < sortedString.Length - 1; i++)
            if (sortedString[i] == sortedString[i+1])
                return false;

        return true;
    }
}
