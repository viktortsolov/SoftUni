using DIContainer.Atributes;
using System;

namespace DIContainer.Modules
{
    public interface IModule
    {
        public void Configure();
        //TODO: Second
        public Type GetMapping(Type interfaceType, Named namedAttribute = null);
        public void CreateMapping<TInterface, TImplementation>();
    }
}
