using SF.Async.EasyDI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.EasyDI.DIDelegatesDefinitions;

namespace SF.Async.EasyDI.Abstractions
{
    public class TypeResolverScopedBase: TypeResolverBase
    {
        protected HashSet<Type> _resolvingTypeSet;

        public TypeResolverScopedBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            ): base(baseTypeToDescriptorItemDelegate,
                resolveCheckDelegate)
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
        }


        public override object GetInstance(Type baseType)
        {
            var compiler = baseType.AsCompilerFromBaseType(this);

            return compiler.Compile().Link();
        }


        public override void Scope(HashSet<Type> resolvingTypeSet)
        {
            _resolvingTypeSet = resolvingTypeSet;
        }

        public override bool IsResolving(Type baseType)
        {
            if(_resolvingTypeSet == null)
            {
                return false;
            }
            return _resolvingTypeSet.Contains(baseType);
        }

        public override void AddToScopeSet(Type baseType)
        {
            if (_resolvingTypeSet == null)
            {
                return;
            }
            _resolvingTypeSet.Add(baseType);
        }
    }
}
