using System;
using System.Linq;
using System.Collections.Generic;

public static class NucleotideCount
{
    private static readonly int NUCLEOTIDE_MAX_COUNT = 4; 

    public static IDictionary<char, int> Count(string sequence)
    {
        var nucleotide_count = new Dictionary<char, int>{ ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };
        
        sequence
            .GroupBy(nucleotide => nucleotide)
            .ToList()
            .ForEach(group => nucleotide_count[group.Key] = group.Count());

        return nucleotide_count.Keys.Count() > NUCLEOTIDE_MAX_COUNT ? throw new ArgumentException() : nucleotide_count;
    }
}