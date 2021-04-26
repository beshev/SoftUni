using CustomDependencyInjectionFramework.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TestCustomInjectionFramework.IO;
using TestCustomInjectionFramework.Models;

namespace TestCustomInjectionFramework.Module
{
    public class CustomModule : AbstractModule
    {
        public CustomModule(IDictionary<Type, Dictionary<string, Type>> implementations, IDictionary<Type, object> instances) : base(implementations, instances)
        {
        }

        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
        }
    }
}
