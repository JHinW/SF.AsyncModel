using SF.Async.EasyDI.Abstractions;
using SF.Async.EasyDI.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Compiler
{
    public class EnumrableCompiler : CompilerBase
    {
        private ICompiler _typeCompiler;

        private Type _type;

        public EnumrableCompiler(Type type)
        {
            _type = type;
        }

        public override ICompiler Compile()
        {
            if (!IsCompiled)
            {
                if (_compilerList.Count() == 0)
                {
                    throw new InvalidOperationException("Error: why there are no ChildrenCompiler .");
                }

                _typeCompiler = new LazyCompiler(() =>
                {
                    var results = _compilerList.Select(complier =>
                    {
                        return complier.Compile().Link();
                    });
                    return EnumrableHelper.CreateEnumrable(_type, results.ToArray());
                });

                _typeCompiler.Compile();
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
