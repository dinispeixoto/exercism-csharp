using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) => multiples
        .Where(multiple => multiple != 0)
        .SelectMany(multiple => Enumerable.Range(0, max).Where(number => number % multiple == 0)).Distinct()
        .Sum(number => number);
}