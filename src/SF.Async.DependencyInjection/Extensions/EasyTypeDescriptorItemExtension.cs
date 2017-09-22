using SF.Async.DependencyInjection.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection.Extensions
{
    public static class EasyTypeDescriptorItemExtension
    {
        public static ITypeCompiler AsCompiler(this EasyTypeDescriptorItem item, bool isIEnumerable, ITypeResolver resolver)
        {
            if (isIEnumerable)
            {

                var compiler = new TypeCompiler(isIEnumerable, null, resolver);

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
