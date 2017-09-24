using EasyDI.Tests.mock;
using SF.Async.EasyDI;
using SF.Async.EasyDI.Usages;
using Xunit;

namespace EasyDI.Tests
{

    public class ContainerTest
    {

        [Fact]
        public void EasyTypeContainerTest()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(typeof(string), "hellow world!");
            container.AddDescriptor(typeof(string), discripor);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(string));

            Assert.Equal("hellow world!", result);
        }


        [Fact]
        public void EasyTypeContainerTest_withConstructor()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(typeof(ClassWithParamLessConstructor), new ClassWithParamLessConstructor());
            container.AddDescriptor(typeof(ClassWithParamLessConstructor), discripor);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(ClassWithParamLessConstructor));

            Assert.Equal(typeof(ClassWithParamLessConstructor), result.GetType());
        }

        [Fact]
        public void EasyTypeContainerTest_withConstructor_implemented_factory()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(
                typeof(ClassWithParamLessConstructor), 
                (helpResolver) => {
                return new ClassWithParamLessConstructor();
            });
            container.AddDescriptor(typeof(ClassWithParamLessConstructor), discripor);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(ClassWithParamLessConstructor));

            Assert.Equal(typeof(ClassWithParamLessConstructor), result.GetType());
        }


        [Fact]
        public void EasyTypeContainerTest_withConstructor_implemented_type()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(
                typeof(ClassWithParamLessConstructor),
               typeof(ClassWithParamLessConstructor));
            container.AddDescriptor(typeof(ClassWithParamLessConstructor), discripor);
            var resolver = container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(ClassWithParamLessConstructor));

            Assert.Equal(typeof(ClassWithParamLessConstructor), result.GetType());
        }

    }
}
