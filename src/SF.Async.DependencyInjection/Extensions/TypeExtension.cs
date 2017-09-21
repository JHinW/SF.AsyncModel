using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SF.Async.DependencyInjection.Extensions
{
    public static class TypeExtension
    {  
        public static object TypeAsObject(this Type implementedType, 
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
                    throw new InvalidOperationException("hi");
                }
            }

            if(bestConstructor == null)
            {
                throw new InvalidOperationException("hi");
            }

            var instanceAsParam = transfer(bestConstructor.GetParameters().Select(p=> p.ParameterType));
            bestConstructor.Invoke(instanceAsParam.ToArray());
            return null;
        }

        public static object TypeAsObject(this Type implementedType, ITypeResolver resolver)
        {
            return implementedType.TypeAsObject(resolver, typeList => {
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
    }
}
