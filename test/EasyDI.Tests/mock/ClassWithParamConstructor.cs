using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDI.Tests.mock
{
    public class ClassWithParamConstructor
    {

        public ClassWithParamConstructor(string test)
        {
            ID = test;
        }

        public string ID = "hellow world2!";
    }
}
