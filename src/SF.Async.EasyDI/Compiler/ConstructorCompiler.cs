using SF.Async.EasyDI.Abstractions;
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
    public class ConstructorCompiler : CompilerBase
    {
        private ConstructorInfo _constructorInfo = null;

        private ICompiler _typeCompiler;

        private IResolver _resolver;

        public ConstructorCompiler(ConstructorInfo constructorInfo, IResolver resolver)
        {
            _constructorInfo = constructorInfo;
            _resolver = resolver;
        }

        public override ICompiler Compile()
        {
            if (!_isCompiled)
            {
                if (_constructorInfo != null)
                {
                    _typeCompiler = _constructorInfo.AsCompiler(this, _resolver);
                    _typeCompiler.Compile();
                }
                else
                {
                    throw new InvalidOperationException("Error: ConstructorInfo is null");
                }
                _isCompiled = true;
            }

            return this;
        }

        public override object Link()
        {
            return _typeCompiler
               // .Compile()
                .Link();
        }
    }
}
