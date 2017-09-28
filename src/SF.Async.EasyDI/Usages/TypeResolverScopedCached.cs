using SF.Async.EasyDI.Abstractions;
using System;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Usages
{
    public class TypeResolverScopedCached : TypeResolverScopedCachedBase
    {
        public TypeResolverScopedCached(
          BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
          ResolveCheckDelegate resolveCheckDelegate,
          GetOrCreateDelegate getOrCreateDelegate
          ) : base(baseTypeToDescriptorItemDelegate,
              resolveCheckDelegate,
              getOrCreateDelegate)
        {
        }

    }
}
