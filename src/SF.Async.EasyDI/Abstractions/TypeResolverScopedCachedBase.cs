using SF.Async.EasyDI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Abstractions
{
    public class TypeResolverScopedCachedBase: TypeResolverScopedBase
    {
        private GetOrCreateDelegate _getOrCreateDelegate;

        public TypeResolverScopedCachedBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate,
            GetOrCreateDelegate getOrCreateDelegate
            ): base(baseTypeToDescriptorItemDelegate,
                resolveCheckDelegate)
        {
            _getOrCreateDelegate = getOrCreateDelegate;
        }


        public override object GetInstance(Type baseType)
        {
            var compiler = _getOrCreateDelegate(baseType, () => baseType.AsCompilerFromBaseType(this));
            return compiler.Compile().Link();
        }
    }
}
