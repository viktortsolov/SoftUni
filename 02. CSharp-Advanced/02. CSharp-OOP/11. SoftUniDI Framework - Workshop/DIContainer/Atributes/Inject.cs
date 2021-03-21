using System;

namespace DIContainer.Atributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class Inject : Attribute
    {

    }
}
