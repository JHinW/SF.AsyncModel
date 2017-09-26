using SF.Async.EasyDI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Abstractions
{
    public abstract class TypeResolverBase : IResolver
    {

        public BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        public ResolveCheckDelegate _resolveCheckDelegate;

        private HashSet<Type> _resolvingTypeSet;

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
            var compiler = baseType.AsCompilerFromBaseType(this);
            return compiler.Compile().Link();
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

        public void Scope(HashSet<Type> resolvingTypeSet)
        {
            _resolvingTypeSet = resolvingTypeSet;
        }

        public bool IsResolving(Type baseType)
        {
            return _resolvingTypeSet.Contains(baseType);
        }

        public void AddToScopeSet(Type baseType)
        {
            _resolvingTypeSet.Add(baseType);
        }
    }
}
