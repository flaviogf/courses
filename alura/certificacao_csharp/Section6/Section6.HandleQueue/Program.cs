using System;
using System.Collections.Generic;

namespace Section6.HandleQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            var flavio = "Flavio";
            var luis = "Luis";
            var fatima = "Fatima";
            var fernando = "Fernando";

            var queue = new CustomerQueue();

            queue
            .Enqueue(flavio)
            .Enqueue(luis)
            .Enqueue(fatima)
            .Enqueue(fernando);

            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
            Console.WriteLine(queue.Dequeue().GetOrElse("No customers"));
        }
    }

    public class CustomerQueue
    {
        private Queue<string> _customers = new Queue<string>();

        public CustomerQueue Enqueue(string customer)
        {
            _customers.Enqueue(customer);

            return this;
        }

        public Maybe<string> Dequeue()
        {
            _customers.TryDequeue(out var customer);

            return Maybe<string>.Of(customer);
        }

        public Maybe<string> Peek()
        {
            _customers.TryPeek(out var customer);

            return Maybe<string>.Of(customer);
        }
    }

    public class Maybe<T> where T : class
    {
        private T _value;

        private Maybe(T value)
        {
            _value = value;
        }

        public static Maybe<T> Of(T value)
        {
            return new Maybe<T>(value);
        }

        public T GetOrElse(T value)
        {
            return _value ?? value;
        }
    }
}
