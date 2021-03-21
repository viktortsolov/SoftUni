using DIContainer.Atributes;
using DIContainer.Modules;

namespace DIContainer.Injectors
{
    public class Injector
    {
        private IModule module;
        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            return default(TClass);
        }
    }
}
