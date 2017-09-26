using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Core.Abstractions
{
    public abstract class FollowingBase : IFollowing
    {
        private MesageContextDelegate _mesageContextDelegate;

        private SemaphoreSlim _metex = new SemaphoreSlim(10);

        public FollowingBase(MesageContextDelegate mesageContextDelegate)
        {
            _mesageContextDelegate = mesageContextDelegate;
        }

        protected virtual IMessageContext Compose(Immutables immutables, Delegates.BackResult backDelegate)
        {
            return null;
        }

        public Task CatchAsync(Immutables immutable, Delegates.BackResult BackResultDelegate)
        {
            return Task.Factory.StartNew(async () =>
            {
                var context = Compose(immutable, BackResultDelegate);

                if (_mesageContextDelegate != null && context != null)
                {
                    try
                    {
                        await _metex.WaitAsync();
                        await _mesageContextDelegate(context);
                    }

                    catch(Exception e)
                    {
                        var another = immutable.Add("exception", null);
                        await BackResultDelegate(another);
                    }
                    finally
                    {
                        _metex.Release();
                    }
                    
                }
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

        }

        
    }
}
