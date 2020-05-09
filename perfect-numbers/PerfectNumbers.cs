using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number) => 
        number.ClassifySum(Enumerable.Range(1, number - 1).Where(x => x.IsFactorOf(number)).Sum());

    private static Classification ClassifySum(this int number, int sum) =>
        sum == number ? Classification.Perfect : sum > number ? Classification.Abundant : Classification.Deficient;

    private static bool IsFactorOf(this int x, int number) => number % x == 0;
}