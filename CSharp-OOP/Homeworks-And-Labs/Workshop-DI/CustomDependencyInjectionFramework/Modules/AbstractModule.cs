using CustomDependencyInjectionFramework.Attributes;
using CustomDependencyInjectionFramework.Modules.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDependencyInjectionFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> _implementations;

        private IDictionary<Type, object> _instances;

        public AbstractModule(IDictionary<Type, Dictionary<string, Type>> implementations, IDictionary<Type, object> instances)
        {
            this._implementations = implementations;
            this._instances = instances;
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (this._implementations.ContainsKey(typeof(TInter)) == false)
            {
                this._implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }
            this._implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this._implementations[currentInterface];

            Type type = null;
            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: " + currentInterface.FullName);
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;
                string dependecyName = named.Name;
                type = currentImplementation[dependecyName];
            }
            return type;
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            this._instances.TryGetValue(type, out object value);
            return value;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (this._instances.ContainsKey(implementation) == false)
            {
                this._instances.Add(implementation, instance);
            }
        }
    }
}
