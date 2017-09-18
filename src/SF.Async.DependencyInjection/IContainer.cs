using System;

namespace SF.Async.DependencyInjection
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IContainer
    {
         void AddInstance(string key, EasyInstance instance);

         void RemoveInstance<T>(string key);
    }
}
