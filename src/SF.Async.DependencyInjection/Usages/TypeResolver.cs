using SF.Async.DependencyInjection.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.DependencyInjection.DIDelegatesDefinitions;

namespace SF.Async.DependencyInjection.Usages
{
    public class TypeResolver : TypeTrackerBase
    {
        public TypeResolver(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate
          ): base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate)
        {
        }

    }
}
