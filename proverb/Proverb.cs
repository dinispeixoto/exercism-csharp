using System;
using System.Linq;

public static class Proverb {
    private static string Sentence (string firstWord, string secondWord) => $"For want of a {firstWord} the {secondWord} was lost.";
    private static string LastSentence (string word) => $"And all for the want of a {word}.";

    public static string[] Recite (string[] subjects) => subjects
        .Select ((element, index) => (index == subjects.Length - 1) ?
            LastSentence (subjects.First ()) : Sentence (element, subjects[index + 1]))
        .ToArray ();
}