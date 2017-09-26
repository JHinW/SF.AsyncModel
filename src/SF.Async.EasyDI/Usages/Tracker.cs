using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Usages
{
    public class Tracker : TrackerBase
    {

        private IResolver _resolver;

        public Tracker(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate
          ): base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate)
        {
            
        }

        public override object Track(Type type)
        {
            _resolver = new TypeResolver(
                _baseTypeToDescriptorItemDelegate,
                _resolveCheckDelegate);

            _resolver.Scope(new HashSet<Type>());

            return _resolver.GetInstance(type);
        }
    }
}
