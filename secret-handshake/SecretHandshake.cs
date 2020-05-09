using System;
using System.Linq;
using System.Collections.Generic;

public static class SecretHandshake
{
    public static readonly Dictionary<int, string> Secrets = new Dictionary<int, string>()
    {
        { 1, "wink"},
        { 2, "double blink"},
        { 4, "close your eyes"},
        { 8, "jump" },
    };

    public static string[] Commands(int commandValue)
    {
        var secrets = new int[] { 1, 2, 4, 8 }
            .Where(n => n == (commandValue & n))
            .Select(n => Secrets[n]);

        return 16 == (commandValue & 16) ? secrets.Reverse().ToArray() : secrets.ToArray();
    }
}
