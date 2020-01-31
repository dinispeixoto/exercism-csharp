using System;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide) => String.Concat(nucleotide.Select(letter => letter switch
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        _   => ' '
    }));
}