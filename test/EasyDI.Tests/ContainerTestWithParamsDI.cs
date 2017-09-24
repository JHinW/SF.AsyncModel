using EasyDI.Tests.mock;
using SF.Async.EasyDI;
using SF.Async.EasyDI.Usages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDI.Tests
{
    public class ContainerTestWithParamsDI
    {
        [Fact]
        public void paraType_DI_test()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(
                typeof(ClassWithParamConstructor),
               typeof(ClassWithParamConstructor));

            var discripor2 = EasyTypeDescriptor.Create(typeof(string), "hellow world, flag1!");
            var discripor3 = EasyTypeDescriptor.Create(typeof(ClassWithParamLessConstructor), new ClassWithParamLessConstructor());
            container.AddDescriptor(typeof(ClassWithParamConstructor), discripor);
            container.AddDescriptor(typeof(string), discripor2);
            container.AddDescriptor(typeof(ClassWithParamLessConstructor), discripor2);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(ClassWithParamConstructor));

            Assert.Equal(typeof(ClassWithParamConstructor), result.GetType());
        }

        [Fact]
        public void paraType_DI_test_two_inputs()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(
                typeof(ClassWithParamLessConstructor),
               typeof(ClassWithParamLessConstructor));

            var discripor2 = EasyTypeDescriptor.Create(typeof(string), "hellow world, flag1!");
            var discripor3 = EasyTypeDescriptor.Create(typeof(ClassWithTwoParamConstructor), typeof(ClassWithTwoParamConstructor));
            container.AddDescriptor(typeof(ClassWithParamLessConstructor), discripor);
            container.AddDescriptor(typeof(string), discripor2);
            container.AddDescriptor(typeof(ClassWithTwoParamConstructor), discripor3);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(ClassWithTwoParamConstructor));

            Assert.Equal(typeof(ClassWithTwoParamConstructor), result.GetType());
        }
    }
}
