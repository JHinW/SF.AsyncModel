using SF.Async.EasyDI.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Extensions
{
    public static class ConstructorInfoExtension
    {
        public static ICompiler AsCompiler(
            this ConstructorInfo constructor,
            ICompiler parentCompiler,
            IResolver typeResolver)
        {
            if (constructor == null)
            {
                throw new ArgumentNullException("Error: constructor is null.");
            }

            var paras = constructor.GetParameters();
            foreach (var para in paras)
            {
                parentCompiler.DependencyTo(
                    para.ParameterType.AsCompilerFromBaseType(typeResolver));
            }

            var param = parentCompiler.ChildrenCompiler.Select(linker =>
            {
                return linker.Compile().Link();
            }).ToArray();


            Object results = constructor.Invoke(param);

            var typeCompiler = new LazyCompiler(() =>
            {
                return results;

            });

            return typeCompiler;
        }

    }
}
