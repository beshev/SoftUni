using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
