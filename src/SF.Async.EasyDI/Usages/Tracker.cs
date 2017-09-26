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

        public Tracker(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate
          ): base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate)
        {
            
        }

        public override object Track(Type type)
        {
            var resolver = new TypeResolver(
                _baseTypeToDescriptorItemDelegate,
                _resolveCheckDelegate);

            resolver.Scope(new HashSet<Type>());

            return resolver.GetInstance(type);
        }
    }
}
