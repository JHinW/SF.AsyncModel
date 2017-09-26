using SF.Async.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Usage
{
    public class MessageContext : IMessageContext
    {
        public Immutables Immutables { get ; set ; }

        public Delegates.BackResult BackResult { get; set ; }

        public string ID { get; }
    }
}
