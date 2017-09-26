using System;
using System.Collections.Generic;

namespace SF.Async.EasyDI
{
    public interface IResolver
    {
        Object GetInstance(Type baseType);

        bool CanBeResolve(Type baseType);

        EasyTypeDescriptorItem DecriptorResolve(Type baseType);

        void Scope(HashSet<Type> resolvingTypeSet);

        bool IsResolving(Type baseType);

        void AddToScopeSet(Type baseType);
    }
}
