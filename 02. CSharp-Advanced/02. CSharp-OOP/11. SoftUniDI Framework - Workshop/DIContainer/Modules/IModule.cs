using System;

namespace DIContainer.Modules
{
    public interface IModule
    {
        public void Configure();
        public Type GetMapping<TInterface>();
        public void CreateMapping<TInterface, TImplementation>();
    }
}
