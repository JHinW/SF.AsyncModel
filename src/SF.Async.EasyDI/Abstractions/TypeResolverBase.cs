using SF.Async.EasyDI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Abstractions
{
    public abstract class TypeResolverBase : IResolver
    {

        public BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        public ResolveCheckDelegate _resolveCheckDelegate;



        public TypeResolverBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
        }


        public object GetInstance(Type baseType)
        {
            if (_resolveCheckDelegate(baseType))
            {
                var item = _baseTypeToDescriptorItemDelegate(baseType);
                var compiler = item.AsCompiler(baseType, this);
                return compiler.Compile().Link();
            }
            else
            {
                throw new InvalidOperationException("Error: Can not be resolved!");
            }
        }
        


        public bool CanBeResolve(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }

        public EasyTypeDescriptorItem DecriptorResolve(Type baseType)
        {
            //if (CanBeResolve(baseType)) throw new InvalidOperationException("Error: Can not be resolved!");

            return _baseTypeToDescriptorItemDelegate(baseType);
        }
    }
}
