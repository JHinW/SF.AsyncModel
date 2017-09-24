using SF.Async.EasyDI.Compiler;
using System;

namespace SF.Async.EasyDI.Extensions
{
    public static class EasyTypeDescriptorExtension
    {
        public static ICompiler AsCompiler(this EasyTypeDescriptor descriptor, IResolver resolver)
        {
            if (descriptor.ImplementationFactory != null)
            {
                var temp = descriptor.ImplementationFactory(resolver);
                //descriptor.ServiceType;
                return new LazyCompiler(() =>
                {
                    return temp;
                });

            }

            if (descriptor.ImplementationInstance != null)
            {
                var temp = descriptor.ImplementationInstance;
                return new LazyCompiler(() =>
                {
                    return temp;
                });
            }

            if (descriptor.ImplementationType != null)
            {
                return descriptor.ImplementationType.AsCompiler(resolver);

            }
            return null;
        }
    }
}
