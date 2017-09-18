using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpeechEntry.src
{
    public static class Extension
    {
        public static ITransferer GetStateFulService(this Controller ctrl, Uri serviceName)
        {
            ITransferer queueService = null;

            while (queueService == null)
            {
                try
                {
                    queueService = ServiceProxy.Create<ITransferer>(serviceName, new ServicePartitionKey(1));
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }

            return queueService;
        }
    }
}
