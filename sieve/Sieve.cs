using System;
using System.Linq;
using System.Collections.Generic;


public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException();

        var primes = new List<int>();
        var numbers = new List<int>();

        for(var x = 2; x <= limit; x++)
            numbers.Add(x);

        var count = numbers.Count();
        var isMultiple = Enumerable.Repeat(false, count).ToArray();

        for (var i = 0; i < count; i++)
        {
            if (isMultiple[i] == false)
            {
                primes.Add(numbers[i]);

                for (var j = i; j < count; j += numbers[i])
                    isMultiple[j] = true;
            }
        }

        return primes.ToArray();
    }
}