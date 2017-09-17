using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Core
{
    public interface IMessageContext: IData
    {
        Immutables Immutables { get; set; }

        BackResult BackResult { get; set; }
    }
}
