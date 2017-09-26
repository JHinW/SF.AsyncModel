using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface ITransferer: IService
    {
        Task<Immutables> DataAsync(Immutables immutables);

        Task<Immutables> DataFromBasicTypeAsync(Object obj);

        Task<Immutables> DataFromMessageAsync(MessageBox messageBox);
    }
}
