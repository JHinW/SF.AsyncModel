using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Async.Core;
using SF.Async.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SF.Async.Usage
{
    public abstract class StateFulDefaultUsage<Ttranserer>: StatefulService, IOperation<Immutables> 
        where Ttranserer: IService
    {
        private IReliableQueue<Immutables> _reliableQueue;

        private IReliableDictionary<string, TaskCompletionSource<Immutables>> _reliableDictionary;

        private IFollowing _following;

        private IServiceEvent _serviceEvent;

        //private Type _transfererType;


        public StateFulDefaultUsage(StatefulServiceContext context, IServiceEvent eventsource, IFollowing following)
            : base(context)
        {
            _serviceEvent = eventsource;
            _following = following;
        }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            yield return new ServiceReplicaListener(context =>
            {

                return new FabricTransportServiceRemotingListener(context,
                    (Ttranserer)Activator.CreateInstance(typeof(Ttranserer), this) );
            }, "StateFulQueueFabricTransportServiceRemotingListener");
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            _reliableQueue = await this.StateManager.GetOrAddAsync<IReliableQueue<Immutables>>("queue");
            _reliableDictionary = await this.StateManager.GetOrAddAsync<IReliableDictionary<string, TaskCompletionSource<Immutables>>>("eventDictionary");

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Immutables immutables = null;
                using (var tx = this.StateManager.CreateTransaction())
                {
                    var result = await _reliableQueue.TryDequeueAsync(tx);
                    immutables = result.HasValue ? result.Value : null;

                    // If an exception is thrown before calling CommitAsync, the transaction aborts, all changes are 
                    // discarded, and nothing is saved to the secondary replicas.

                    await tx.CommitAsync();

                    /*ServiceEventSource.Current.ServiceMessage(this.Context, "Current Counter Value: {0}",
                        result.HasValue ? result.Value.ToString() : "Value does not exist.");
                        */
                    _serviceEvent.LogEvents($"Current Counter Value: { (result.HasValue ? result.Value.ToString() : "") } Value does not exist.");
                }

                if (immutables != null)
                {
                    await _following.CatchAsync(immutables, async (data) =>
                    {
                        await this.ValueAsync(data);
                    });

                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }





        public async Task<Immutables> EnqueueAsync(Immutables immutables)
        {
            using (var tx = this.StateManager.CreateTransaction())
            {
                try
                {
                    var signal = new TaskCompletionSource<Immutables>();
                    await _reliableDictionary.AddAsync(tx, immutables.ID, signal);
                    await _reliableQueue.EnqueueAsync(tx, immutables);


                    await tx.CommitAsync();
                    var ret = await signal.Task;
                    return ret;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        public async virtual Task ValueAsync(Immutables immutables)
        {
            using (var tx = StateManager.CreateTransaction())
            {
                var signalPack = await _reliableDictionary.TryGetValueAsync(tx, immutables.ID);
                if (signalPack.HasValue)
                {
                    signalPack.Value.SetResult(immutables);
                } 
            }

        }
    }
}
