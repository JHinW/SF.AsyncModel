using System;

namespace SF.Async.EasyDI
{
    public interface IResolver
    {
        Object GetInstance(Type baseType);

        bool CanBeResolve(Type baseType);

        EasyTypeDescriptorItem DecriptorResolve(Type baseType);
    }
}
