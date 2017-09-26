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
    }
}
