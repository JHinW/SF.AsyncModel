using System;

namespace SF.Async.EasyDI.Compiler
{
    public class LazyCompiler : ICompiler
    {
        private bool _isCompiled = false;

        public bool IsCompiled { get => _isCompiled; }

        public ICompiler[] ChildrenCompiler => null;

        private Lazy<Object> _lazy = null;

        public LazyCompiler(Func<Object> action)
        {
            _lazy = new Lazy<object>(action);
        }

        public ICompiler Compile()
        {
            if (!_isCompiled)
            {
                _isCompiled = true;

            }      
            return this;
        }

        public ICompiler DependencyTo(ICompiler typeCompiler)
        {
            return this;
        }

        public object Link()
        {
            return _lazy??_lazy.Value;
        }
    }
}
