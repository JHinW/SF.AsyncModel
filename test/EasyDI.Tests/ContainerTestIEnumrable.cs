using SF.Async.EasyDI;
using SF.Async.EasyDI.Usages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDI.Tests
{
    public class ContainerTestIEnumrable
    {
        [Fact]
        public void String_IEnumrable_test()
        {
            var container = new EasyTypeContainer();
            var discripor = EasyTypeDescriptor.Create(typeof(string), "hellow world!");
            var discripor2 = EasyTypeDescriptor.Create(typeof(string), "hellow world2!");
            var discripor3 = EasyTypeDescriptor.Create(typeof(string), "hellow world3!");
            container.AddDescriptor(typeof(string), discripor);
            container.AddDescriptor(typeof(string), discripor2);
            container.AddDescriptor(typeof(string), discripor3);


            Type type = typeof(string);
            // type.ReflectedType.

            var tracker = container.CreateTracker();

            var result = tracker.Track(typeof(IEnumerable<string>));


            Assert.Equal(true, typeof(IEnumerable<string>).IsAssignableFrom(result.GetType()));

        }
    }
}
