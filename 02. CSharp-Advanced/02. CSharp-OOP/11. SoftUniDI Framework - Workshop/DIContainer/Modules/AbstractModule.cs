using System;
using System.Collections.Generic;

namespace DIContainer.Modules
{
    public abstract class AbstractModule : IModule
    {
        private Dictionary<Type, Type> mappings;
        private Dictionary<Type, object> instances;

        protected abstract void Configure();

        //CreateMapping<Ireader, COonsoleReader>();
        public void CreateMapping<TInterface, TImplementation>()
        {
            if (!mappings.ContainsKey(typeof(TInterface)))
            {
                mappings.Add(typeof(TInterface), typeof(TImplementation));
            }
        }

        public TImplementation GetInstance<TImplementation>()
        {
            return (TImplementation)instances[typeof(TImplementation)];
        }

        public void SetInstance<TImplementation>(object instance)
        {
            if (!instances.ContainsKey(typeof(TImplementation)))
            {
                instances[typeof(TImplementation)] = instance;
            }
        }
    }
}
