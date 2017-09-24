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



    }
}
