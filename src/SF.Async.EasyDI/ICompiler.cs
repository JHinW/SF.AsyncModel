using System;

namespace SF.Async.EasyDI
{
    public interface ICompiler
    {
        ICompiler[] ChildrenCompiler { get;}

        ICompiler DependencyTo(ICompiler typeCompiler);

        bool IsCompiled { get; }

        ICompiler Compile();

        Object Link();
    }
}
