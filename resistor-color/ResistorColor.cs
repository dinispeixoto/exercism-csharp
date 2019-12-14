using System;
using System.Linq;

public static class ResistorColor
{
    public static int ColorCode(string color) => ResistorColor
        .Colors()
        .Select((_color, index) => new { _color, index })
        .First(item => item._color.Equals(color)).index;

    public static string[] Colors() => new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
}
