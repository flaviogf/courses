using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class Program
    {
        public static void Main()
        {
            var tasks = new List<Task>
            {
                new Task("001", "Study English", true),
                new Task("002", "Study MSSQL", false)
            };

            tasks.ForEach(Console.WriteLine);
        }
    }
}
