using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Concurrent;

namespace SF.Async.EasyDI.Usages
{
    public class EasyTypeContainer: ContainerBase
    {    
        public EasyTypeContainer()
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
