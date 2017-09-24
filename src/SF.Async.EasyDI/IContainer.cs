using System;

namespace SF.Async.EasyDI
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IContainer
    {
         void AddDescriptor(Type key, EasyTypeDescriptor instance);

         EasyTypeDescriptorItem RemoveInstance(Type key);

         IResolver CreateTypeResolver();

        void Sync();
    }
}
