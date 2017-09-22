using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection.Compiler
{
    public class LazyCompiler : ITypeCompiler
    {
        private bool _isCompiled = false;

        public bool IsCompiled { get => _isCompiled; }

        private Lazy<Object> _lazy = null;

        public LazyCompiler(Func<Object> action)
        {
            _lazy = new Lazy<object>(action);
        }

        public ITypeCompiler Compile()
        {
            if (!_isCompiled)
            {
                _isCompiled = true;

            }      
            return this;
        }

        public ITypeCompiler DependencyTo(ITypeCompiler typeCompiler)
        {
            return this;
        }

        public object Link()
        {
            return _lazy??_lazy.Value;
        }
    }
}
