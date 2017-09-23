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
    public class TypeCompiler : ITypeCompiler
    {
        private IList<ITypeCompiler> _compilerList = new List<ITypeCompiler>();

        private ConstructorInfo _constructorInfo = null;

        private bool _isCompiled = false;

        private ITypeCompiler _typeCompiler;

        private ITypeResolver _resolver;

        public TypeCompiler(bool isIEnumerable, ConstructorInfo constructorInfo, ITypeResolver resolver)
        {
            IsIEnumerable = isIEnumerable;
            constructorInfo = _constructorInfo;
            _resolver = resolver;
        }

        public bool IsIEnumerable { get; }

        public bool IsCompiled { get => _isCompiled; }

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
                var paras = _constructorInfo.GetParameters();
                foreach (var para in paras)
                {
                    _compilerList.Add(
                        _resolver
                        .DecriptorResolve(para.ParameterType)
                        .AsCompiler((para.ParameterType is IEnumerable), _resolver));
                }

                var param = _compilerList.Select(linker =>
                {
                    return linker.Compile().Link();
                }).ToArray();

                Object results = null;

                if (_constructorInfo == null && IsIEnumerable)
                {
                    results = param;
                }
                else
                {
                    results = _constructorInfo.Invoke(param);
                }

                _typeCompiler = new LazyCompiler(() =>
                {
                    return results;

                });
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
