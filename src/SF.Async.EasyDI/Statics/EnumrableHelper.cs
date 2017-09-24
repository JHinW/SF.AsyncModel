using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.EasyDI.Statics
{
    public class EnumrableHelper
    {
        public static Object CreateEnumrable(Type type, object[] parameters)
        {
            Type dictType = typeof(List<>).MakeGenericType(type);
            var lst = Activator.CreateInstance(dictType);
            MethodInfo info = typeof(List<>).MakeGenericType(type).GetMethod("Add");
            foreach (var par in parameters)
            {
                info.Invoke(lst, new[] { par });
            }
            return lst;
        }
    }
}
