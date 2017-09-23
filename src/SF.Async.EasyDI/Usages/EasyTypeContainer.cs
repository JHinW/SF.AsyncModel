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

        public override ITypeResolver CreateTypeResolver()
        {
            return new TypeResolver(
                type => this[type],
                type => this.IsHasKey(type)
                );
        }
    }
}
