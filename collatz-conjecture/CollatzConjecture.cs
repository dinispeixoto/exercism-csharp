using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1) throw new ArgumentException();

        Func<int, int> even_operation = (n) => n / 2;
        Func<int, int> odd_operation = (n) => 3 * n + 1;

        return (number == 1) ? 
            0 : Steps(number % 2 == 0 ? even_operation(number) : odd_operation(number)) + 1;
    }
}