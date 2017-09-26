using EasyDI.Tests.mock.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock.DependencyList
{
    public class ClassB_CircularDepdencyCheck : IClassB
    {
        public IClassC _classC;

        public ClassB_CircularDepdencyCheck(IClassC classC)
        {
            _classC = classC;
        }
    }
}
