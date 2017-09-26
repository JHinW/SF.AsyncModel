using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI
{
    //using OwnedImmutableList = ImmutableList<EasyTypeDescriptor>;
    public struct EasyTypeDescriptorItem
    {
        private EasyTypeDescriptor _item;

        private List<EasyTypeDescriptor> _items;

        public EasyTypeDescriptor Last
        {
            get
            {
                if (_items != null && _items.Count > 0)
                {
                    return _items[_items.Count - 1];
                }

                Debug.Assert(_item != null);
                return _item;
            }
        }

        public int Count
        {
            get
            {
                if (_item == null)
                {
                    Debug.Assert(_items == null);
                    return 0;
                }

                return 1 + (_items?.Count ?? 0);
            }
        }

        public EasyTypeDescriptor this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                if (index == 0)
                {
                    return _item;
                }

                return _items[index - 1];
            }
        }

        public EasyTypeDescriptorItem Add(EasyTypeDescriptor descriptor)
        {

            var newItem = new EasyTypeDescriptorItem();

            if (_item == null)
            {
                Debug.Assert(_items == null);
                newItem._item = descriptor;
            }
            else
            {
                newItem._item = _item;
                newItem._items = _items ?? new List<EasyTypeDescriptor>();
                newItem._items.Add(descriptor);
            }
            return newItem;
        }

    }
}
