using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.DependencyInjection
{
    public interface ITypeResolver
    {
        Object GetInstance(Type baseType);

        bool CanBeResolve(Type baseType);
    }
}
