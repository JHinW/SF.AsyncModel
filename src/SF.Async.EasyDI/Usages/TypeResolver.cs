using SF.Async.EasyDI.Abstractions;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Usages
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
