using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Abstractions
{
    public abstract class TrackerBase : ITracker
    {
        public BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        public ResolveCheckDelegate _resolveCheckDelegate;


        public TrackerBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
        }

        public abstract object Track(Type type);
    }
}
