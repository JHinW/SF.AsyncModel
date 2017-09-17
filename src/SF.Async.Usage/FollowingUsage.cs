using SF.Async.Core;
using SF.Async.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Usage
{
    public class FollowingUsage : FollowingBase
    {
        public FollowingUsage(MesageContextDelegate mesageContextDelegate) 
            : base(mesageContextDelegate)
        {
        }

        protected override IMessageContext Compose(Immutables immutables, Delegates.BackResult backDelegate)
        {
            return new MessageContext
            {
                BackResult = backDelegate,
                Immutables = immutables
            };
        }
    }
}
