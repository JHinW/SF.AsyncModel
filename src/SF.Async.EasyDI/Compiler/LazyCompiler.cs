using System;

namespace SF.Async.EasyDI.Compiler
{
    public class LazyCompiler : ITypeCompiler
    {
        private bool _isCompiled = false;

        public bool IsCompiled { get => _isCompiled; }

        public ITypeCompiler[] ChildrenCompiler => null;

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
