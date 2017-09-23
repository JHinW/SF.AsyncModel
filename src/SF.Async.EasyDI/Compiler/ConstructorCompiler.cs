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
    public class ConstructorCompiler : ITypeCompiler
    {
        private IList<ITypeCompiler> _compilerList = new List<ITypeCompiler>();

        private ConstructorInfo _constructorInfo = null;

        private bool _isCompiled = false;

        private ITypeCompiler _typeCompiler;

        private ITypeResolver _resolver;

        public ConstructorCompiler(ConstructorInfo constructorInfo, ITypeResolver resolver)
        {
            constructorInfo = _constructorInfo;
            _resolver = resolver;
        }

        public bool IsIEnumerable { get; }

        public bool IsCompiled { get => _isCompiled; }

        public ITypeCompiler[] ChildrenCompiler { get=> _compilerList.ToArray(); }

        public ITypeCompiler DependencyTo(ITypeCompiler typeCompiler)
        {
            _compilerList.Add(typeCompiler);
            return this;
        }

        public ITypeCompiler DependencyTo(ITypeCompiler[] typeCompilers)
        {
            foreach (var compiler in typeCompilers)
            {
                _compilerList.Add(compiler);
            }
            
            return this;
        }

        public ITypeCompiler Compile()
        {
            if (!_isCompiled)
            {
                if(_constructorInfo != null)
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
