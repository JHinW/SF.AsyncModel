using EasyDI.Tests.mock.DependencyList;
using EasyDI.Tests.mock.Interface;
using SF.Async.EasyDI.Extensions;
using SF.Async.EasyDI.Usages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDI.Tests
{
    public class ContainerTestDependencyList
    {
        [Fact]
        public void paraType_DI_Interface()
        {
            var box = new EasyTypeContainer();
            box.AddDisp<IClassA>(new ClassA());
            box.AddDisp<IClassB>(typeof(ClassB));
            box.AddDisp<IClassC, ClassC>();
            box.AddDisp<IClassD>( factory => {
                var para = (IClassC)factory.GetInstance(typeof(IClassC));
                var intance =  new ClassD(para);
                return intance;
            });
            box.AddDisp<ClassE, ClassE>();
            var tracker = box.CreateTracker();
            var result = tracker.Track(typeof(ClassE));
            Assert.Equal(typeof(ClassE), result.GetType());

        }

        [Fact]
        public void paraType_DI_Interface_Tracker()
        {
            var box = new EasyTypeContainer();
            box.AddDisp<IClassA>(new ClassA());
            box.AddDisp<IClassB>(typeof(ClassB_CircularDepdencyCheck));
            box.AddDisp<IClassC, ClassC>();
            box.AddDisp<IClassD>(factory => {
                var para = (IClassC)factory.GetInstance(typeof(IClassC));
                var intance = new ClassD(para);
                return intance;
            });

            box.AddDisp<ClassE, ClassE>();
            var tracker = box.CreateTracker();
            var ex = Assert.Throws<InvalidOperationException>(() => tracker.Track(typeof(ClassE)));
            Assert.Equal("Error: Circular Dependency.", ex.Message);
        }
    }
}
