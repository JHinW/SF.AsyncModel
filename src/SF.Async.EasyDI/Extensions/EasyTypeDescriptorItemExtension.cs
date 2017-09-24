using SF.Async.EasyDI.Compiler;
using System;
using System.Collections;
using System.Linq;

namespace SF.Async.EasyDI.Extensions
{
    public static class EasyTypeDescriptorItemExtension
    {
        public static ICompiler AsCompiler(this EasyTypeDescriptorItem item, bool isIEnumerable, IResolver resolver)
        {
            if (isIEnumerable)
            {

                var compiler = new EnumrableCompiler(item.Last.ServiceType);

                for (var i = 0; i < item.Count; i++ )
                {
                    compiler.DependencyTo(item[i].AsCompiler(resolver));
                }

                return compiler;
            }
            else
            {
                return item.Last.AsCompiler(resolver);
            }
        }

        public static ICompiler AsCompiler(this EasyTypeDescriptorItem item, Type baseType, IResolver resolver)
        {
            var realBaseType = baseType;
            if (baseType.IsGenericType)
            {
                var generics = baseType.GetGenericArguments();
                if (generics.Count() == 1)
                {
                    realBaseType = generics[0];

                }
            }

            if (resolver.CanBeResolve(baseType))
            {
                return item.AsCompiler((baseType is IEnumerable), resolver);
            }
            else
            {
                throw new InvalidCastException("Error: Can not be resolved!");
            }


        }

    }
}
