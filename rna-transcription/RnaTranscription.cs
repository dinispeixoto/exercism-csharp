using System;
using System.Linq;

public static class RnaTranscription
{
    public static char NucleotideToRna(this char nucleotide) => nucleotide switch
    {
        'G'     => 'C',
        'C'     => 'G',
        'T'     => 'A',
        'A'     => 'U',
        _       => ' '
    };

    public static string ToRna(string nucleotide) => String.Concat(nucleotide.Select(letter => letter.NucleotideToRna()));
}