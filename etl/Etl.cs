using System;
using System.Linq;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old) => old
        .SelectMany(item => item.Value
            .Select(letter => new { key = item.Key, value = letter}))
        .ToDictionary(item => item.value.ToLower(), item => item.key);
}