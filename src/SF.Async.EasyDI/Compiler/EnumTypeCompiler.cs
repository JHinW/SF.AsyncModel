using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Compiler
{
    public class EnumTypeCompiler : ICompiler
    {
        private IList<ICompiler> _compilerList = new List<ICompiler>();

        public bool _isCompiled = false;


        public EnumTypeCompiler()
        {
        }


        public ICompiler[] ChildrenCompiler => _compilerList.ToArray();

        public bool IsCompiled => _isCompiled;


        public ICompiler DependencyTo(ICompiler typeCompiler)
        {
            _compilerList.Add(typeCompiler);
            return this;
        }

        public ICompiler DependencyTo(ICompiler[] typeCompilers)
        {
            foreach (var compiler in typeCompilers)
            {
                _compilerList.Add(compiler);
            }

            return this;
        }


        public ICompiler Compile()
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
