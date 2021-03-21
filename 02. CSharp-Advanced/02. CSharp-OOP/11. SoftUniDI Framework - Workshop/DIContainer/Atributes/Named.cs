using System;

namespace DIContainer.Atributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class Named : Attribute
    {
        public Named(Type type)
        {
            Type = type;
        }
        public Type Type { get; set; }
    }
}
