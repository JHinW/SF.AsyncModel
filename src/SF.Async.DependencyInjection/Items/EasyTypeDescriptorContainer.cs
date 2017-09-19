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
        private ConcurrentDictionary<string, EasyTypeDescriptorItem> _container;

        public EasyTypeDescriptorContainer()
        {
            _container = new ConcurrentDictionary<string, EasyTypeDescriptorItem>();
        }

        public void AddDescriptor(string key, EasyTypeDescriptor descriptor)
        {

            var item = new EasyTypeDescriptorItem();      
            _container.AddOrUpdate(key, item.Add(descriptor), (_key, oldValue) =>{
                return oldValue.Add(descriptor);
            });
        }

        public EasyTypeDescriptorItem this[string index]
        {
            get
            {
                return _container[index];
            }
        }

        public EasyTypeDescriptorItem RemoveInstance(string key)
        {
            _container.TryRemove(key, out EasyTypeDescriptorItem value);
            return value;
        }


    }
}
