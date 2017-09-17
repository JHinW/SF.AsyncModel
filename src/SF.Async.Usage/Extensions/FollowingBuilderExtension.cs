using SF.Async.Core;
using SF.Async.Core.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SF.Async.Core.Delegates;

namespace SF.Async.Usage.Extensions
{
    using FuncLikeCompWithTwoParas = Func<IMessageContext, MesageContextDelegate, Task>;

    using FuncLikeCompWihtSinglePare = Func<IMessageContext, Task>;

    public static class FollowingBuilderExtension
    {
        public static IFollowingBuilder UseFollowerEx(this IFollowingBuilder builder, FuncLikeCompWithTwoParas funcLikeCompWithTwoParas)
        {
            builder.UseFollower(next => message => funcLikeCompWithTwoParas(message, next));
            return builder;
        }

        public static IFollowingBuilder UseFollowerEx(this IFollowingBuilder builder, FuncLikeCompWihtSinglePare funcLikeCompWihtSinglePare)
        {
            builder.UseFollower(next => message => funcLikeCompWihtSinglePare(message));
            return builder;
        }

    }
}
