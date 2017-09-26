using EasyDI.Tests.mock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock.DependencyList
{
    class ClassD: IClassD
    {
        public IClassC _classC;

        public ClassD(IClassC classC)
        {
            _classC = classC;
        }
    }
}
