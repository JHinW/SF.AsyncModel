using SF.Async.DependencyInjection.Items;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection.Items
{
    public class EasyTypeDescriptorContainer: IContainer
    {
        private ConcurrentDictionary<Type, EasyTypeDescriptorItem> _container;

        public EasyTypeDescriptorContainer()
        {
            _container = new ConcurrentDictionary<Type, EasyTypeDescriptorItem>();
        }

        public void AddDescriptor(Type key, EasyTypeDescriptor descriptor)
        {

            var item = new EasyTypeDescriptorItem();
            _container.AddOrUpdate(key, item.Add(descriptor), (_key, oldValue) =>{
                return oldValue.Add(descriptor);
            });
        }

        public EasyTypeDescriptorItem this[Type index]
        {
            get
            {
                return _container[index];
            }
        }

        public EasyTypeDescriptorItem RemoveInstance(Type key)
        {
            _container.TryRemove(key, out EasyTypeDescriptorItem value);
            return value;
        }

        private bool IsHasKey(Type key)
        {
            return _container.ContainsKey(key);
        }
    }
}
