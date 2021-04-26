using CustomDependencyInjectionFramework.Modules.Contracts;

namespace CustomDependencyInjectionFramework.Injectors
{
    public static class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
