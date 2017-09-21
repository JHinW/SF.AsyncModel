using SF.Async.DependencyInjection.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.DependencyInjection.DIDelegatesDefinitions;

namespace SF.Async.DependencyInjection.Abstractions
{
    public abstract class TypeTrackerBase : ITypeTracker, ITypeResolver
    {
        private BaseTypeToDescriptorItem _baseTypeToDescriptorItem;

        public Type[] GetConstructorParamTypes(Type implementType)
        {
            var generics = implementType.GetGenericArguments();

            return null;

        }


        private Object ConstructInstanceFromImplementedType(Type implementType)
        {
            return null;
        }

        public DIDelegatesDefinitions.TypeResolverDelegate GetResolverDelegate(EasyTypeDescriptor easyTypeDescriptor)
        {
           // var 

            return type =>
            {

                return null;
            };
        }

        public virtual object EasyTypeDescriptorToInstance(EasyTypeDescriptor easyTypeDescriptor)
        {
            if(easyTypeDescriptor.ImplementationFactory != null)
            {
                return easyTypeDescriptor.ImplementationFactory(this);
            }

            if(easyTypeDescriptor.ImplementationInstance != null)
            {
                return easyTypeDescriptor.ImplementationInstance;
            }

            if (easyTypeDescriptor.ImplementationType != null)
            {
                return easyTypeDescriptor.ImplementationType.TypeAsObject(this);
            }

            return null;
        }

        public object GetInstance(Type baseType)
        {
            if (baseType.IsGenericType)
            {
                if(baseType is IEnumerable)
                {
                    return GetInstanceFromEnumerableBaseType(baseType);

                }
                else
                {
                    throw new InvalidOperationException("hi");
                }
            }
            else
            {
                return GetInstanceFromNormalBaseType(baseType);
            }
        }
        
        private object GetInstanceFromEnumerableBaseType(Type baseType)
        {
            var argTypes = baseType.GetGenericArguments();
            if (argTypes.Length == 1)
            {
                var outs = new List<object>();
                var descriptor = _baseTypeToDescriptorItem(argTypes[0]);
                for(var i = 0; i< descriptor.Count; i++)
                {
                    outs.Add(EasyTypeDescriptorToInstance(descriptor[i]));
                }

                return outs;
            }
            return null;
        }

        private object GetInstanceFromNormalBaseType(Type baseType)
        {
            return EasyTypeDescriptorToInstance(_baseTypeToDescriptorItem(baseType).Last);
        }

        public bool CanBeResolve(Type baseType)
        {
            throw new NotImplementedException();
        }
    }
}
