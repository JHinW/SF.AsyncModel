using System;

namespace SF.Async.EasyDI
{
    public interface ITypeCompiler
    {
        ITypeCompiler DependencyTo(ITypeCompiler typeCompiler);

        bool IsCompiled { get; }

        ITypeCompiler Compile();

        Object Link();
    }
}
