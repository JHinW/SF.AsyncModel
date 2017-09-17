using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Usage
{
    public interface IFollower
    {
        string FollowerName { get; }

        Task Process(IMessageContext context);
    }
}
