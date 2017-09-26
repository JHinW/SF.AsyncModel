using SF.Async.Core.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Usage.Extensions
{
    public static class FollowingBuilderExtensionForFollower
    {
        public static IFollowingBuilder UseFollower<Tfollower>(this IFollowingBuilder builder)
            where Tfollower: IFollower
        {

            builder.UseFollowerEx((context, next) =>
            {
                var instance = (Tfollower)Activator.CreateInstance(typeof(Tfollower), typeof(Tfollower).FullName, next);
                return instance.Process(context);
            });
            return builder;
        }
    }
}
