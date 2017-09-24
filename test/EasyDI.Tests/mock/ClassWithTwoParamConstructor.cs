using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock
{
    public class ClassWithTwoParamConstructor
    {
        public ClassWithTwoParamConstructor(string test, ClassWithParamLessConstructor _classWithParamLessConstructor)
        {
            ID = test;
            ClassWithParamLessConstructor = _classWithParamLessConstructor;
        }

        public string ID = "hellow world2!";

        public ClassWithParamLessConstructor ClassWithParamLessConstructor;
    }
}
