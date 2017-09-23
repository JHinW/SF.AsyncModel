using SF.Async.EasyDI.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace SF.Async.EasyDI.Extensions
{
    public static class TypeExtension
    {  
        public static object AsInstance(this Type implementedType, 
            ITypeResolver resolver, 
            Func<IEnumerable<Type>, IEnumerable<Object>> transfer)
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
                if(paras.Count() == resolveFilter.Count())
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("Error: Invalid dependency type.");
                }
            }

            if(bestConstructor == null)
            {
                throw new InvalidOperationException("Error: No appropriate constructor.");
            }

            var instanceAsParam = transfer(bestConstructor.GetParameters().Select(p=> p.ParameterType));
            bestConstructor.Invoke(instanceAsParam.ToArray());
            return null;
        }

        public static object AsInstance(this Type implementedType, ITypeResolver resolver)
        {
            return implementedType.AsInstance(resolver, typeList => {
                if(typeList.Count() > 0 )
                {
                    return typeList.Select(baseType => 
                    {
                        return resolver.GetInstance(baseType);
                    });
                }

                return new List<Type>();
            });
        }


        public static ITypeCompiler AsCompiler(this Type implementedType, ITypeResolver resolver)
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

    }
}
