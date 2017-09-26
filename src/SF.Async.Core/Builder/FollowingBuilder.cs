using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Core.Abstractions;
using static SF.Async.Core.Delegates;

namespace SF.Async.Core.Builder
{

    using MesageContextDelegateComp = Func<MesageContextDelegate, MesageContextDelegate>;

    public class FollowingBuilder : IFollowingBuilder
    {
        private IList<MesageContextDelegateComp> _mesageContextDelegateCompList = new List<MesageContextDelegateComp>();

        public Tfollowing FollowingBuild<Tfollowing>() where Tfollowing: FollowingBase
        {
            MesageContextDelegate app = context =>
            {
                return Task.CompletedTask;
            };

            foreach (var component in _mesageContextDelegateCompList.Reverse())
            {
                app = component(app);
            }

            return (Tfollowing)Activator.CreateInstance(typeof(Tfollowing), app);
        }

        public IFollowingBuilder UseFollower(MesageContextDelegateComp messageDelegateComp)
        {
            _mesageContextDelegateCompList.Add(messageDelegateComp);
            return this;
        }
    }
}
