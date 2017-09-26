using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI
{
    public interface ITracker
    {
        Object Track(Type type);
    }
}
