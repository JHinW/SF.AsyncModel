using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection
{
    using TypeFactory = Func<IDResolver, Type>;
    public class EasyInstance
    {
        private EasyInstance(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public EasyInstance(
            Type serviceType,
            Type implementationType): this(serviceType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        public EasyInstance(
            Type serviceType,
            TypeFactory factory): this(serviceType)
        {
            ImplementationFactory = factory;
        }

        public EasyInstance(
            Type serviceType,
            object instance): this(serviceType)
        {

            ImplementationInstance = instance;
        }


        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public Func<IDResolver, object> ImplementationFactory { get; }

        public object ImplementationInstance { get; }

        public static EasyInstance Create(Type serviceType, Type implementationType)
        {
            return new EasyInstance(serviceType, implementationType);
        }

        public static EasyInstance Create(Type serviceType, TypeFactory factory)
        {
            return new EasyInstance(serviceType, factory);
        }

        public static EasyInstance Create(Type serviceType, object instance)
        {
            return new EasyInstance(serviceType, instance);
        }
    }
}
