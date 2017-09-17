using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Core;

namespace SF.Async.Usage
{
    public abstract class FollowerUsageBase : IFollower
    {
        public string FollowerName { get; }
        public Delegates.MesageContextDelegate _next { get;}

        public FollowerUsageBase(string name, Delegates.MesageContextDelegate next)
        {
            FollowerName = name;
            _next = next;
        }

        public virtual IMessageContext Reducer(IMessageContext context, Immutables immutables)
        {
            context.Immutables = immutables;
            return context;
        }

        public async virtual Task Process(IMessageContext context)
        {
            var ret = Reducer(context, context.Immutables);
            await _next(ret);
        }
    }
}
