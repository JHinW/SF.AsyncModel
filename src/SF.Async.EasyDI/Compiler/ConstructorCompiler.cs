using SF.Async.EasyDI.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Compiler
{
    public class ConstructorCompiler : ICompiler
    {
        private IList<ICompiler> _compilerList = new List<ICompiler>();

        private ConstructorInfo _constructorInfo = null;

        private bool _isCompiled = false;

        private ICompiler _typeCompiler;

        private IResolver _resolver;

        public ConstructorCompiler(ConstructorInfo constructorInfo, IResolver resolver)
        {
            _constructorInfo = constructorInfo;
            _resolver = resolver;
        }

        public bool IsCompiled { get => _isCompiled; }

        public ICompiler[] ChildrenCompiler { get => _compilerList.ToArray(); }

        public ICompiler DependencyTo(ICompiler typeCompiler)
        {
            _compilerList.Add(typeCompiler);
            return this;
        }

        public ICompiler Compile()
        {
            if (!_isCompiled)
            {
                if (_constructorInfo != null)
                {
                    _typeCompiler = _constructorInfo.AsCompiler(this, _resolver);
                }
                else
                {
                    throw new InvalidOperationException("Error: ConstructorInfo is null");
                }
                _isCompiled = true;
            }

            return this;
        }

        public object Link()
        {
            return _typeCompiler
                .Compile()
                .Link();
        }
    }
}
