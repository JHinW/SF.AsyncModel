using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Abstractions
{
    public abstract class CompilerBase : ICompiler
    {
        protected IList<ICompiler> _compilerList = new List<ICompiler>();

        protected bool _isCompiled = false;

        public ICompiler[] ChildrenCompiler => _compilerList.ToArray();

        public bool IsCompiled => _isCompiled;


        public abstract ICompiler Compile();

        public ICompiler DependencyTo(ICompiler typeCompiler)
        {
            _compilerList.Add(typeCompiler);
            return this;
        }

        public abstract object Link();
    }
}
