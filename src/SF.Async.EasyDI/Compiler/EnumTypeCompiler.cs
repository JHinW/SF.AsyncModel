using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Compiler
{
    public class EnumTypeCompiler : ITypeCompiler
    {
        private IList<ITypeCompiler> _compilerList = new List<ITypeCompiler>();

        public bool _isCompiled = false;


        public EnumTypeCompiler()
        {
        }


        public ITypeCompiler[] ChildrenCompiler => _compilerList.ToArray();

        public bool IsCompiled => _isCompiled;


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
            if (!IsCompiled)
            {
                if(_compilerList.Count() == 0)
                {
                    throw new InvalidOperationException("Error: why there is no ChildrenCompiler .");
                }
                _isCompiled = true;
            }

            return this;
        }

        public object Link()
        {
            return _compilerList.Select(complier => {
                return complier.Compile().Link();
            });
        }
    }
}
