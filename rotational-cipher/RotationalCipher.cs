using System;
using System.Linq;

public static class RotationalCipher
{
    private static char calculateFirstLetter(char c) => Char.IsUpper(c) ? 'A' : 'a';

    public static string Rotate(string text, int shiftKey) => string.Concat(text.Select(letter => Char.IsLetter(letter) ? 
        (char)((((letter + shiftKey) - calculateFirstLetter(letter)) % 26) + calculateFirstLetter(letter)) : letter));
}