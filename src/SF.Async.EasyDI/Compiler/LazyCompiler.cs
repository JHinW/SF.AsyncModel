using SF.Async.EasyDI.Abstractions;
using System;

namespace SF.Async.EasyDI.Compiler
{
    public class LazyCompiler : CompilerBase
    {
        private Lazy<Object> _lazy = null;

        private Type _originalType;

        public LazyCompiler(Func<Object> action)
        {
            _lazy = new Lazy<object>(action);
            this._compilerList = null;
        }

        public LazyCompiler(Func<Object> action, Type type)
        {
            _lazy = new Lazy<object>(action);
            _originalType = type;
            this._compilerList = null;
        }

        public override ICompiler Compile()
        {
            if (!_isCompiled)
            {
                _isCompiled = true;

            }      
            return this;
        }

        public override object Link()
        {
            return _lazy != null? _lazy.Value : null;
        }
    }
}
