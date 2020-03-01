using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static IDictionary<int, IEnumerable<char>> scores = new Dictionary<int, IEnumerable<char>> {
        { 1, new[] { 'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T' } },
        { 2, new[] { 'D', 'G' } },
        { 3, new[] { 'B', 'C', 'M', 'P' } },
        { 4, new[] { 'F', 'H', 'V', 'W', 'Y' } },
        { 5, new[] { 'K' } },
        { 8, new[] { 'J', 'X' } },
        { 10, new[] { 'Q', 'Z' } },
    };

    private static int LetterScore(char c) => scores
        .SelectMany(item => item.Value
            .Select(value => new { letter = value, score = item.Key }))
        .ToDictionary(item => item.letter, item => item.score)[Char.ToUpper(c)];
    
    public static int Score(string input) => input.Select(LetterScore).Sum();
}