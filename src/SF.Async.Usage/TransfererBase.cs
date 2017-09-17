using Microsoft.ServiceFabric.Services.Remoting;
using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Usage
{
    public abstract class TransfererBase : ITransferer
    {

        private IOperation<Immutables> _operation;

        public TransfererBase(IOperation<Immutables> operation)
        {
            _operation = operation;
        }

        public async Task<Immutables> DataAsync(Immutables immutables)
        {
            var ret = await _operation.EnqueueAsync(immutables);
            return ret;
        }

        public async Task<Immutables> DataFromBasicTypeAsync(object obj)
        {
            var ret = await this.DataAsync(Immutables.CreateImmutables(obj));
            return ret;
        }

        public async Task<Immutables> DataFromMessageAsync(MessageBox messageBox)
        {
            var immu = new Immutables();
            var ret = await this.DataAsync(immu.Add("origin", messageBox));
            return ret;
        }
    }
}
