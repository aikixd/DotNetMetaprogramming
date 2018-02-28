using System;

namespace _Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class GenerateBuilderAttribute : Attribute
    {
        public GenerateBuilderAttribute()
        {
            
        }
    }
}
