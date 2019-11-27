using System;
using System.Linq.Expressions;

namespace Section10.ExpressionTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = Expression.Parameter(typeof(int), "x");

            var two = Expression.Constant(2, typeof(int));

            var multiply = Expression.Multiply(x, two);

            var duplicate = Expression.Lambda<Func<int, int>>(multiply, x);

            var half = DivisorVisitor.Modify(duplicate);

            Console.WriteLine(duplicate.Compile()(2));

            Console.WriteLine(half.Compile()(2));
        }
    }

    public class DivisorVisitor : ExpressionVisitor
    {
        public static Expression<Func<int, int>> Modify(Expression node)
        {
            var visitor = new DivisorVisitor();

            return (Expression<Func<int, int>>)visitor.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            return Expression.Divide(node.Left, node.Right);
        }
    }
}
