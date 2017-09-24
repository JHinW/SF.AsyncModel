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
                throw new InvalidOperationException("Error: constructor is null.");
            }

            var paras = constructor.GetParameters();
            foreach (var para in paras)
            {
                if (typeResolver.CanBeResolve(para.ParameterType))
                {
                    parentCompiler.DependencyTo(
                       typeResolver
                       .DecriptorResolve(para.ParameterType)
                       .AsCompiler(para.ParameterType, typeResolver));
                }
                else
                {
                    throw new InvalidOperationException("Error: Can not be resolved!");

                }
            }

            var param = parentCompiler.ChildrenCompiler.Select(linker =>
            {
                return linker.Compile().Link();
            }).ToArray();


            Object results = null;

            results = constructor.Invoke(param);

            var typeCompiler = new LazyCompiler(() =>
            {
                return results;

            });

            return typeCompiler;
        }

    }
}
