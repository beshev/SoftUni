using CustomDependencyInjectionFramework.Attributes;
using CustomDependencyInjectionFramework.Modules.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CustomDependencyInjectionFramework.Injectors
{
    public class Injector
    {
        private IModule _module;

        public Injector(IModule module)
        {
            _module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            if (desireClass == null) return default(TClass);

            var constructors = desireClass.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (CheckForConstructorInjection<TClass>() == false) continue;

                var inject = (Inject)constructor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                var parametersTypes = constructor.GetParameters();
                var constructorParams = new object[parametersTypes.Length];

                var i = 0;

                foreach (var parametersType in parametersTypes)
                {
                    var named = parametersType.GetCustomAttribute(typeof(Named));
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this._module.GetMapping(parametersType.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this._module.GetMapping(parametersType.ParameterType, named);
                    }

                    if (parametersType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this._module.GetInstance(dependency);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this._module.SetInstance(parametersType.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }
            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this._module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this._module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);
            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject),true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    var named = field.GetCustomAttributes(typeof(Named), true);
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this._module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this._module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this._module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this._module.SetInstance(dependency, instance);
                        }
                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }
            return (TClass)desireClassInstance;
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException
                    ("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }
    }
}
