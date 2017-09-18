using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection
{
    public class InstanceContainer: IContainer
    {
        private ImmutableDictionary<string, Object> _container;

        public InstanceContainer()
        {
            _container = ImmutableDictionary<string, Object>.Empty;
        }

        public void AddInstance(string key, EasyInstance service)
        {
            _container = _container.Add(key, service);
        }

        private T GetInstance<T>(string key)
        {
            return (T)_container[key];
        }

        public void RemoveInstance<T>(string key)
        {
            _container = _container.Remove(key);
        }


    }
}
