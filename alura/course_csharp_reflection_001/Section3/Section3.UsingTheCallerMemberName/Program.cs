using System;
using System.Reflection;

namespace Section3.UsingTheCallerMemberName
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action("Home", "Index");
            Action("User", "Index");
        }

        private static void Action(string controller, string action)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var typeName = $"{assemblyName}.Controllers.{controller}Controller";
            var instance = Activator.CreateInstance(assemblyName, typeName).Unwrap();
            var method = instance.GetType().GetMethod(action);
            var result = method.Invoke(instance, Array.Empty<object>());
            Console.WriteLine(result.ToString().Replace("@User", "Flavio"));
        }
    }
}
