using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public class Delegates
    {
        public delegate Task BackResult(Immutables immutables);

        public delegate Task MesageContextDelegate(IMessageContext messageContext);

        public delegate void MessageLogger(string log);
    }
}
