using System;
using System.Reflection;

namespace Section3.CreatingInstancesAndInvokingMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var typeName = $"{assemblyName}.HomeController";
            var wrapper = Activator.CreateInstance(assemblyName, typeName);
            var controller = wrapper.Unwrap();
            var action = controller.GetType().GetMethod("Index");
            var result = action.Invoke(controller, Array.Empty<object>());
            Console.WriteLine(result);
        }
    }
}