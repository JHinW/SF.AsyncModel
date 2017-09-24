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

        public static ICompiler AsCompiler(this EasyTypeDescriptorItem item, Type baseType, IResolver resolver)
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
