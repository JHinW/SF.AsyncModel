using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Usage
{
    public abstract class FollowerUsageGenericBase<Ttransferer> : FollowerUsageBase
        where Ttransferer : TransfererBase
    {
        private string _uri;

        public FollowerUsageGenericBase(
            string name, 
            Delegates.MesageContextDelegate next
            ): base(name, next)
        {

        }

        public virtual ITransferer GetService()
        {
            return (Ttransferer)ServiceProxy.Create<Ttransferer>(new Uri(_uri), new ServicePartitionKey(1));
        }

        public override IMessageContext Reducer(IMessageContext context, Immutables immutables)
        {
            context.Immutables = immutables;
            return context;
        }

        public async override Task Process(IMessageContext context)
        {
            var service = GetService();
            var ret = await service.DataAsync(context.Immutables);           
            await _next(Reducer(context, ret));
        }
    }
}
