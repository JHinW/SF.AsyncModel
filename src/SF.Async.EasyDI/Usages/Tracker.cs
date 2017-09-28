using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Usages
{
    public class Tracker : TrackerBase
    {

        private ConcurrentDictionary<Type, ICompiler> _cacheItems = new ConcurrentDictionary<Type, ICompiler>();

        public Tracker(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate
          ) : base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate)
        {

        }

        public override object Track(Type type)
        {
            var resolver = new TypeResolverScopedCached(
                _baseTypeToDescriptorItemDelegate,
                _resolveCheckDelegate,
                GetOrCreate
                );

            resolver.Scope(new HashSet<Type>());

            return resolver.GetInstance(type);
        }

        private ICompiler GetOrCreate(Type type, Func<ICompiler> factory)
        {
            return _cacheItems.GetOrAdd(type, factory());
        }
    }
}
