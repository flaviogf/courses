using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Section7.MaxMinAverageAndExtensionMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new ApplicationContext();

            var max = context.Employes.Max(it => it.Salary);
            var min = context.Employes.Min(it => it.Salary);
            var average = context.Employes.Average(it => it.Salary);
            var median = context.Employes.Median(it => it.Salary);

            var tendency = (from employe in context.Employes
                            group employe by 1 into grouping
                            select new
                            {
                                Max = grouping.Max(it => it.Salary),
                                Min = grouping.Min(it => it.Salary),
                                Average = grouping.Average(it => it.Salary),
                            }).First();

            Console.WriteLine("Max: {0:F2} (with group by)", tendency.Max);
            Console.WriteLine("Min: {0:F2} (with group by)", tendency.Min);
            Console.WriteLine("Average: {0:F2} (with group by)", tendency.Average);

            Console.WriteLine("Max: {0:F2}", max);
            Console.WriteLine("Min: {0:F2}", min);
            Console.WriteLine("Average: {0:F2}", average);
            Console.WriteLine("Median: {0:F2}", median);
        }
    }

    public static class LinqExtensions
    {
        public static decimal Median<TSource>(this IEnumerable<TSource> items, Expression<Func<TSource, decimal>> expression)
        {
            var function = expression.Compile();

            var firstPosition = items.Count() / 2;
            var secondPosition = (items.Count() - 1) / 2;

            var first = items.Skip(firstPosition).Select(function).First();
            var second = items.Skip(secondPosition).Select(function).First();

            var median = (first + second) / 2;

            return median;
        }
    }
}
