using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public class MessageBox: IMessageBox
    {
        public string ID { get; }

        public string Type { get; set; }

        public string PayLoad { get; set; }
    }
}
