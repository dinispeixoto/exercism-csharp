using System;

public static class CollatzConjecture
{
    private const int INITIAL_STEPS = 0;

    public static int Steps(int number) => _Steps(number, INITIAL_STEPS);

    private static int _Steps(int number, int steps)
    {
        if (number == 1) return steps;
        if (number < 1) throw new ArgumentException();

        Func<int, int> even_operation = (n) => n / 2;
        Func<int, int> odd_operation = (n) => 3 * n + 1;

        return _Steps(number % 2 == 0 ? even_operation(number) : odd_operation(number), ++steps);
    }
}