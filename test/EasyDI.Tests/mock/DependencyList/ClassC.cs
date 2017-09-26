using EasyDI.Tests.mock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock.DependencyList
{
    class ClassC: IClassC
    {
        public IClassB _classB;

        public ClassC(IClassB classB)
        {
            _classB = classB;
        }
    }
}
