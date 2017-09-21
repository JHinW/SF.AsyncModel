using SF.Async.DependencyInjection.Abstractions;
using System;
using System.Collections.Concurrent;

namespace SF.Async.DependencyInjection.Usages
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
