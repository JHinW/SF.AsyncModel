using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Core
{
    public interface IMessageBox: IData
    {
        string Type { get; set; }

        string PayLoad { get; set; }
    }
}