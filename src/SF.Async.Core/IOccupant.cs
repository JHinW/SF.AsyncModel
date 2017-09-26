using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IOccupant<TReq, TRes>
    {
        Task<TRes> GetResultAsync(TReq message);
    }
}
