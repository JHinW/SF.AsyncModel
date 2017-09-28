using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Usages
{
    public class TypeResolverScoped: TypeResolverScopedBase
    {
        public TypeResolverScoped(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate
          ) : base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate)
        {
        }
    }
}
