using System;

namespace SF.Async.DependencyInjection
{
    public class DIDelegatesDefinitions
    {

        public delegate object TypeResolverDelegate(EasyTypeDescriptor easyTypeDescriptor);


        public delegate EasyTypeDescriptorItem BaseTypeToDescriptorItemDelegate(Type baseType);


        public delegate bool ResolveCheckDelegate(Type baseType);
    }
}
