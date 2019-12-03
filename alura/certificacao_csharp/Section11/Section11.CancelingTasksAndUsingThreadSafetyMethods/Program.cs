using System;
using System.Threading;
using System.Threading.Tasks;

namespace Section11.CancelingTasksAndUsingThreadSafetyMethods
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            async Task Example01()
            {
                using var cancellationTokenSource = new CancellationTokenSource();

                Console.WriteLine("Enter any key to finish.");

                var task = Clock(cancellationTokenSource.Token);

                Console.ReadKey();

                cancellationTokenSource.Cancel();

                Console.WriteLine("Clock has already stopped");

                await task;
            }

            async Task Example02()
            {
                using var cancellationTokenSource = new CancellationTokenSource();

                Console.WriteLine("Enter any key to stop stopwatch.");

                var task = StopWatch(10, cancellationTokenSource.Token);

                Console.ReadKey();

                try
                {
                    cancellationTokenSource.Cancel();
                    await task;
                    Console.WriteLine("Stopwatch has came to finish");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Stopwatch has stopped");
                }
            }

            void Example03()
            {
                var counter = new Counter();

                var first = new Thread(() =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        counter.Increase();
                    }
                });

                var second = new Thread(() =>
                {
                    for (var i = 0; i < 50; i++)
                    {
                        counter.Increase();
                    }
                });

                first.Start();
                second.Start();

                first.Join();
                second.Join();

                counter.Print();
            }

            await Example01();

            await Example02();

            Example03();
        }

        public async static Task Clock(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Tic");
                await Task.Delay(500);
                Console.WriteLine("Tac");
                await Task.Delay(500);
            }
        }

        public async static Task StopWatch(int count, CancellationToken cancellationToken)
        {
            var rest = count;

            while ((rest -= 1) > 0)
            {
                Console.WriteLine(rest);
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(500);
                cancellationToken.ThrowIfCancellationRequested();
            }

            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    public class Counter
    {
        private object countLock = new object();

        public int Count { get; private set; }

        public void Increase()
        {
            lock (countLock)
            {
                Count += 1;
            }
        }

        public void Print()
        {
            Console.WriteLine("Count: {0}", Count);
        }
    }
}
