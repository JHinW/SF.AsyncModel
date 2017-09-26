using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Extensions
{
    using TypeFactory = Func<IResolver, Object>;

    public static class IContainerExtension
    {
        public static IContainer AddDisp<T>(this IContainer container, Type implmentedType)
        {
            var discriptor = EasyTypeDescriptor.Create(typeof(T), implmentedType);
            container.AddDescriptor(discriptor.ServiceType, discriptor);
            return container;
        }

        public static IContainer AddDisp<Tbase, Timplement>(this IContainer container)
        {
            var discriptor = EasyTypeDescriptor.Create(typeof(Tbase), typeof(Timplement));
            container.AddDescriptor(discriptor.ServiceType, discriptor);
            return container;
        }

        public static IContainer AddDisp<T>(this IContainer container, object instance)
        {
            var discriptor = EasyTypeDescriptor.Create(typeof(T), instance);
            container.AddDescriptor(discriptor.ServiceType, discriptor);
            return container;
        }

        public static IContainer AddDisp<T>(this IContainer container, TypeFactory factory)
        {
            var discriptor = EasyTypeDescriptor.Create(typeof(T), factory);
            container.AddDescriptor(discriptor.ServiceType, discriptor);
            return container;
        }
    }
}
