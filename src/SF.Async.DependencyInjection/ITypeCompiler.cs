using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection
{
    public interface ITypeCompiler
    {
        ITypeCompiler DependencyTo(ITypeCompiler typeCompiler);

        bool IsCompiled { get; }

        ITypeCompiler Compile();

        Object Link();
    }
}
