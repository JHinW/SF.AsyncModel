using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Usages
{
    public class CommonContainer : ContainerBase
    {
        public CommonContainer(IEnumerable<EasyTypeDescriptor> descriptors)
            : base(descriptors)
        {
        }

        public override ITracker CreateTracker()
        {
            return new Tracker(
                type => this[type],
                type => this.IsHasKey(type)
                );
        }

        public override IResolver CreateTypeResolver()
        {
            return new TypeResolverScoped(
                type => this[type],
                type => this.IsHasKey(type)
                );
        }
    }
}
