using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classSystem = Type.GetType("System.Object");
            var assembly = Assembly.GetAssembly(classSystem);

            var types = assembly.GetTypes();

            Console.WriteLine("The class listed contais obsolete attribute");
            foreach (var type in types)
            {
                if(type.GetCustomAttribute<ObsoleteAttribute>() != null)
                {
                    Console.WriteLine($"Class: {type.FullName}");
                }
            }

            Console.WriteLine();

            Console.WriteLine("The methods listed contais obsolete attribute");
            foreach (var type in types)
            {
                var methods = type.GetMethods();

                foreach (var method in methods)

                if (method.GetCustomAttribute<ObsoleteAttribute>() != null)
                {
                    Console.WriteLine($"Method: {method.Name} - Class: {type.FullName}");
                }
            }

            Console.ReadLine();

        }
    }
}
