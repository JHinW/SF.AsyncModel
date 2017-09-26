using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI
{
    using TypeFactory = Func<IResolver, Object>;
    public class EasyTypeDescriptor
    {
        private EasyTypeDescriptor(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public EasyTypeDescriptor(
            Type serviceType,
            Type implementationType): this(serviceType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        public EasyTypeDescriptor(
            Type serviceType,
            TypeFactory factory): this(serviceType)
        {
            ImplementationFactory = factory;
        }

        public EasyTypeDescriptor(
            Type serviceType,
            object instance): this(serviceType)
        {

            ImplementationInstance = instance;
        }


        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public Func<IResolver, object> ImplementationFactory { get; }

        public object ImplementationInstance { get; }

        public static EasyTypeDescriptor Create(Type serviceType, Type implementationType)
        {
            return new EasyTypeDescriptor(serviceType, implementationType);
        }

        public static EasyTypeDescriptor Create(Type serviceType, TypeFactory factory)
        {
            return new EasyTypeDescriptor(serviceType, factory);
        }

        public static EasyTypeDescriptor Create(Type serviceType, object instance)
        {
            return new EasyTypeDescriptor(serviceType, instance);
        }
    }
}
