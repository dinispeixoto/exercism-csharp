using System;

public static class Grains
{
    public static ulong Square(int n) => n < 1 || n > 64 ? throw new ArgumentOutOfRangeException() : n == 1 ? 1 : 2 * Square(n-1);

    public static ulong Total() => 2 * Square(64) - 1;
}