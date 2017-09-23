using SF.Async.EasyDI.Compiler;
using System;

namespace SF.Async.EasyDI.Extensions
{
    public static class EasyTypeDescriptorExtension
    {
        public static Lazy<object> AsLazy(this EasyTypeDescriptor descriptor, ITypeResolver resolver)
        {
            if (descriptor.ImplementationFactory != null)
            {
                var temp = descriptor.ImplementationFactory(resolver);
                return  new Lazy<object>(() =>
                {
                    return temp;
                });

            }

            if (descriptor.ImplementationInstance != null)
            {
                var temp = descriptor.ImplementationInstance;
                return new Lazy<object>(() =>
                {
                    return temp;
                });
            }

            if (descriptor.ImplementationType != null)
            {
                var temp = descriptor.ImplementationType.AsInstance(resolver);
                return new Lazy<object>(() =>
                {
                    return temp;
                });
            }

            return null;
        }



        public static ITypeCompiler AsCompiler(this EasyTypeDescriptor descriptor, ITypeResolver resolver)
        {
            if (descriptor.ImplementationFactory != null)
            {
                var temp = descriptor.ImplementationFactory(resolver);
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
