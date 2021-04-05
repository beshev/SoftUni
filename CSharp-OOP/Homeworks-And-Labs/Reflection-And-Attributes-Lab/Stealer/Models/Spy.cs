using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer.Models
{
    public class Spy
    {
        public string StealFieldInfo(string investingatedClass, params string[] requestedFileds)
        {
            Type classType = Type.GetType(investingatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Class under investigation: {classType.FullName}");
            foreach (var field in classFields.Where(f => requestedFileds.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return result.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            // Object classInstane = Activator.CreateInstance(classType);

            StringBuilder result = new StringBuilder();
            foreach (var field in classFields)
            {
                result.AppendLine($"{field.Name} must be private");
            }

            foreach (var getter in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{getter.Name} have to be public!");
            }
            foreach (var setter in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{setter.Name} have to be private!");
            }
            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classPrivetMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {(classType.BaseType).FullName}");
            foreach (var method in classPrivetMethods)
            {
                sb.AppendLine($"{method.Name}");
            }


            return sb.ToString().TrimEnd();
        }

        public string CollectGettesAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            foreach (var metod in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{metod.Name} will return {metod.ReturnType}");
            }
            foreach (var metod in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{metod.Name} will set field of {metod.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
