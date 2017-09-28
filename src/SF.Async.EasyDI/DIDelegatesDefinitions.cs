using System;

namespace SF.Async.EasyDI
{
    public class DIDelegatesDefinitions
    {

        public delegate object TypeResolverDelegate(EasyTypeDescriptor easyTypeDescriptor);


        public delegate EasyTypeDescriptorItem BaseTypeToDescriptorItemDelegate(Type baseType);


        public delegate bool ResolveCheckDelegate(Type baseType);

        public delegate ICompiler GetOrCreateDelegate(Type baseType, Func<ICompiler> factory);
    }
}
