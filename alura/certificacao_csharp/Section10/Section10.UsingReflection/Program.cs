using System;

namespace Section10.UsingReflection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var report = new Report("XPTO");

            var type = report.GetType();

            Console.WriteLine(type.ToString());

            foreach (var member in type.GetMembers())
            {
                Console.WriteLine(member.ToString());
            }

            var setName = type.GetMethod("set_Name");

            setName.Invoke(report, new object[] { "Changed" });

            Console.WriteLine(report.Name);
        }
    }
}
