using System;

namespace SF.Async.DependencyInjection
{
    /// <summary>
    /// singleton
    /// </summary>
    public interface IContainer
    {
         void AddInstance(string key, Object service);

         T GetInstance<T>(string key);

         void RemoveInstance<T>(string key);
    }
}
