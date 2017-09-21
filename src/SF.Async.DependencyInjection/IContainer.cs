using System;

namespace SF.Async.DependencyInjection
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IContainer
    {
         void AddDescriptor(Type key, EasyTypeDescriptor instance);

         EasyTypeDescriptorItem RemoveInstance(Type key);

         ITypeResolver CreateTypeResolver();

        void Sync();
    }
}
