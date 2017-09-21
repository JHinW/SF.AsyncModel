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

        public BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        public ResolveCheckDelegate _resolveCheckDelegate;

        public TypeTrackerBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
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
                var descriptor = _baseTypeToDescriptorItemDelegate(argTypes[0]);
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
            return EasyTypeDescriptorToInstance(_baseTypeToDescriptorItemDelegate(baseType).Last);
        }

        public bool CanBeResolve(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }
    }
}
