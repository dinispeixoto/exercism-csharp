using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int sum = 0, length = number.ToString().Length;

        Func<int, int, int> Pow = (x, y) => Enumerable.Repeat(x, y).Aggregate(1, (x, y) => x * y);

        for (int tmp = number; tmp > 0; tmp /= 10)
            sum += Pow(tmp % 10, length);

        return sum == number;
    }
}