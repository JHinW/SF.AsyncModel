using SF.Async.DependencyInjection.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection
{
    public class DIDelegatesDefinitions
    {

        public delegate object TypeResolverDelegate(EasyTypeDescriptor easyTypeDescriptor);


        public delegate EasyTypeDescriptorItem BaseTypeToDescriptorItem(Type baseType);
    }
}
