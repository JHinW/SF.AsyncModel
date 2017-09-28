using SF.Async.EasyDI.Compiler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace SF.Async.EasyDI.Extensions
{
    public static class TypeExtension
    {
        public static ICompiler AsCompiler(this Type implementedType, IResolver resolver)
        {
            var constructors = implementedType.GetTypeInfo()
              .DeclaredConstructors
              .Where(constructor => constructor.IsPublic)
              .ToArray();

            Array.Sort(constructors,
            (a, b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));

            ConstructorInfo bestConstructor = null;
            foreach (var constructor in constructors)
            {
                bestConstructor = constructor;
                var paras = constructor.GetParameters();
                var resolveFilter = paras.Where(p => resolver.CanBeResolve(p.ParameterType));
                if (paras.Count() == resolveFilter.Count())
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("Error: Invalid dependency type.");
                }
            }

            if (bestConstructor == null)
            {
                throw new InvalidOperationException("Error: No appropriate constructor.");
            }

            return new ConstructorCompiler(bestConstructor, resolver);
        }


        public static ICompiler AsCompilerFromBaseType(this Type baseType, IResolver resolver)
        {
            if (resolver.IsResolving(baseType))
            {
                throw new InvalidOperationException("Error: Circular Dependency.");
            }
            else
            {
                resolver.AddToScopeSet(baseType);
            }

            var realBaseType = baseType;

            var IsGenericTypeAndIsIEnumerable = 
                typeof(IEnumerable).IsAssignableFrom(baseType) 
                && baseType.IsGenericType;

            if (IsGenericTypeAndIsIEnumerable 
                && !resolver.CanBeResolve(realBaseType))
            {
                var clonedGenerics = baseType.GetGenericArguments();
                if (clonedGenerics.Count() == 1)
                {
                    realBaseType = clonedGenerics[0];

                }
            }

            if (resolver.CanBeResolve(realBaseType))
            {
                var item = resolver.DecriptorResolve(realBaseType);
                return item.AsCompiler(IsGenericTypeAndIsIEnumerable, resolver);
            }
            else
            {
                throw new InvalidCastException("Error: Can not be resolved!");
            }
        }

    }
}
