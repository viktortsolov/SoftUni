namespace DIContainer.Modules
{
    public interface IModule
    {
        public void CreateMapping<TInterface, TImplementation>();
        public void Configure();
        public void SetInstance<T>(T type, object instance);
        public T GetInstance<T>();
    }
}
