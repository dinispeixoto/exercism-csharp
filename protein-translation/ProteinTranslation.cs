using System;
using System.Linq;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private const int NUCLEOIDE_COUNT = 3;
    private const string STOP_WORD = "STOP";

    private static IDictionary<string, string> RnaMapping = new Dictionary<string, string>
    {
        { "AUG", "Methionine" },
        { "UUU", "Phenylalanine" },
        { "UUC", "Phenylalanine" },
        { "UUA", "Leucine" },
        { "UUG", "Leucine" },
        { "UCU", "Serine" },
        { "UCC", "Serine" },
        { "UCA", "Serine" },
        { "UCG", "Serine" },
        { "UAU", "Tyrosine" },
        { "UAC", "Tyrosine" },
        { "UGU", "Cysteine" },
        { "UGC", "Cysteine" },
        { "UGG", "Tryptophan" },
        { "UAA", STOP_WORD },
        { "UAG", STOP_WORD },
        { "UGA", STOP_WORD }
    };

    public static string[] Proteins(string strand) => strand
        .Select((nucleoide_letter, index) => new { nucleoide = nucleoide_letter, group = index/NUCLEOIDE_COUNT })
        .GroupBy(tuple => tuple.group, tuple => tuple.nucleoide)
        .Select(group => RnaMapping[string.Join("", group)])
        .TakeWhile(condon => condon != STOP_WORD)
        .ToArray();
}