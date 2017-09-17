using SF.Async.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Core.Builder
{
    using MesageContextDelegateComp = Func<MesageContextDelegate, MesageContextDelegate>;
    public interface IFollowingBuilder
    {
        IFollowingBuilder UseFollower(MesageContextDelegateComp mesageContextDelegateComp);
    }
}
