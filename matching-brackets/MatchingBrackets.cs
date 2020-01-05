using System;
using System.Linq;
using System.Collections;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        var bracketsStack = new Stack();

        try
        {
            return input.Select(letter => {
                switch (letter)
                {
                    case '[': case '{': case '(':
                        bracketsStack.Push(letter); return true;
                    case ']': case '}':
                        return (char)bracketsStack.Pop() != (char)letter-2 ? false : true;
                    case ')':
                        return (char)bracketsStack.Pop() != (char)letter-1 ? false : true;
                    default:
                        return true;
                }
            }).All(result => result) && bracketsStack.Count == 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
