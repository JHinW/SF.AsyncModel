using System;

namespace SF.Async.EasyDI.Compiler
{
    public class LazyCompiler : ICompiler
    {
        private bool _isCompiled = false;

        public bool IsCompiled { get => _isCompiled; }

        public ICompiler[] ChildrenCompiler => null;

        private Lazy<Object> _lazy = null;

        private Type _originalType;

        public LazyCompiler(Func<Object> action)
        {
            _lazy = new Lazy<object>(action);
        }

        public LazyCompiler(Func<Object> action, Type type)
        {
            _lazy = new Lazy<object>(action);
            _originalType = type;
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
            return _lazy != null? _lazy.Value : null;
        }
    }
}
