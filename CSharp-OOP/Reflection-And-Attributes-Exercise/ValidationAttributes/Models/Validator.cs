using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] allProp = obj.GetType().GetProperties();
            foreach (var prop in allProp)
            {
                var allAttr = prop
                    .GetCustomAttributes(true)
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();


                foreach (var attr in allAttr)
                {
                    if (attr.IsValid(prop.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
