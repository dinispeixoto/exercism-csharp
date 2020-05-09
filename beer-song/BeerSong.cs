using System;
using System.Linq;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
        => string.Join("\n", Enumerable.Range(startBottles - takeDown + 1, takeDown).Reverse().Select(Verse)).TrimEnd();

    private static string Verse(int number)
        => number == 0 ? NoBottles() : 
            $"{Bottle(number)} of beer on the wall, {Bottle(number)} of beer.\n" + 
            $"Take {(number == 1 ? "it" : "one")} down and pass it around, " + 
            $"{Bottle(number - 1)} of beer on the wall.\n";

    private static string NoBottles() 
        =>  "No more bottles of beer on the wall, no more bottles of beer.\n" +
            "Go to the store and buy some more, 99 bottles of beer on the wall.\n"; 

    public static string Bottle(int n) => n == 0 ? "no more bottles" : n == 1 ? "1 bottle" : $"{n} bottles";
}
