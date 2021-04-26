using CustomDependencyInjectionFramework.Injectors;
using CustomDependencyInjectionFramework.Modules.Contracts;
using System;
using System.Collections.Generic;
using TestCustomInjectionFramework.Module;

namespace TestCustomInjectionFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomModule customModule = 
                new CustomModule(new Dictionary<Type,Dictionary<string,Type>>(),new Dictionary<Type,object>());

            Injector injector = DependencyInjector.CreateInjector(customModule);

            Engine engine = injector.Inject<Engine>();
            engine.Run();

        }
    }
}
