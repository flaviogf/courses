using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo
{
    public class Program
    {
        public static void Main()
        {
            var tasks = new List<Task>
            {
                new Task(1, "Study English", true)
            };

            tasks.ForEach(Console.WriteLine);
        }
    }
}
