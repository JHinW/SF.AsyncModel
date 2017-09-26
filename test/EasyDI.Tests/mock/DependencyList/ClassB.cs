using EasyDI.Tests.mock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock.DependencyList
{
    public class ClassB: IClassB
    {
        public IClassA _classA;

        public ClassB(IClassA classA)
        {
            _classA = classA;
        }
    }
}
