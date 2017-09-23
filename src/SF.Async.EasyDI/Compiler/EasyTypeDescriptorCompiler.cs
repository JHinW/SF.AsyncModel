using SF.Async.EasyDI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Compiler
{
    public class EasyTypeDescriptorCompiler : ITypeCompiler
    {
        private IList<ITypeCompiler> linkerList = new List<ITypeCompiler>();

        private EasyTypeDescriptor _easyTypeDescriptor;

        private Lazy<Object> _lazyOBj = null;

        public bool _isCompiled = false;

        public EasyTypeDescriptorCompiler(EasyTypeDescriptor easyTypeDescriptor)
        {
            _easyTypeDescriptor = easyTypeDescriptor;
        }

        public bool IsCompiled { get => _isCompiled; }

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
            linkerList.Add(typeCompiler);
            return this;
        }

        public object Link()
        {
            if(_lazyOBj != null)
            {
                return _lazyOBj.Value;
            }

            throw new InvalidOperationException("error");
        }
    }
}
