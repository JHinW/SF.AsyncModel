using SF.Async.EasyDI.Compiler;
using System;
using System.Collections;
using System.Linq;

namespace SF.Async.EasyDI.Extensions
{
    public static class EasyTypeDescriptorItemExtension
    {
        public static ITypeCompiler AsCompiler(this EasyTypeDescriptorItem item, bool isIEnumerable, ITypeResolver resolver)
        {
            if (isIEnumerable)
            {

                var compiler = new EnumTypeCompiler();

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

        public static ITypeCompiler AsCompiler(this EasyTypeDescriptorItem item, Type baseType, ITypeResolver resolver)
        {
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
