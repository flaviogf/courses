using System;
using System.Collections.Generic;

Generate(10).Print();

GeneratePrimeFactorsOf(10).Print();

/**
 *  bad
 */
List<int> Generate(int n)
{
    var x = new List<int>();

    for (int i = 2; n > 1; i++)
    {
        for (; n % i == 0; n /= i)
        {
            x.Add(i);
        }
    }

    return x;
}

/**
 *  good
 */
List<int> GeneratePrimeFactorsOf(int input)
{
    var primeFactors = new List<int>();

    for (int candidateFactor = 2; input > 1; candidateFactor++)
    {
        while (input % candidateFactor == 0)
        {
            primeFactors.Add(candidateFactor);

            input /= candidateFactor;
        }
    }

    return primeFactors;
}

public static class IEnumerableExtensions
{
    public static void Print<T>(this IEnumerable<T> items)
    {
        foreach (var it in items)
        {
            Console.WriteLine(it);
        }
    }
}