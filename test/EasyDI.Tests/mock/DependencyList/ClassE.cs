using EasyDI.Tests.mock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock.DependencyList
{
    class ClassE: IClassE
    {
        public IClassD _ClassD;

        public ClassE(IClassD classD)
        {
            _ClassD = classD;
        }
    }
}
