using System;
using System.Linq;

public static class StringExtensions
{
    public static bool IsAnagramOf(this string baseWord, string testWord)
        => String.Concat(baseWord.ToLower().OrderBy(c => c)).Equals(String.Concat(testWord.ToLower().OrderBy(c => c)));

    public static bool IsEqualTo(this string baseWord, string testWord)
        => baseWord.ToLower().Equals(testWord.ToLower());
}

public class Anagram
{
    private readonly string baseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
        => potentialMatches.Where(word => !word.IsEqualTo(this.baseWord) && word.IsAnagramOf(this.baseWord)).ToArray();
}