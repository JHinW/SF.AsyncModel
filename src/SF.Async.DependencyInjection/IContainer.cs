using SF.Async.DependencyInjection.Items;
using System;

namespace SF.Async.DependencyInjection
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IContainer
    {
         void AddDescriptor(string key, EasyTypeDescriptor instance);

         EasyTypeDescriptorItem RemoveInstance(string key);
    }
}
