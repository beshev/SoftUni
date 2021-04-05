using AuthorProblem.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem.Models
{
    public class Tracker 
    {
        public static void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
