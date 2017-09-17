
using SF.Async.Core.Builder;
using System;
using System.Fabric;
using static SF.Async.Core.Delegates;

namespace SF.Async.Usage
{
    using EntryMiddleware = Action<FollowingBuilder>;

    public class StateFulDefaultUsageBuilder
    {
        private StatefulServiceContext _statefulServiceContext;

        private MessageLogger _messageLogger;

        private EntryMiddleware _entryMiddleware;

        public StateFulDefaultUsageBuilder(StatefulServiceContext statefulServiceContext)
        {
            _statefulServiceContext = statefulServiceContext;
        }

        public StateFulDefaultUsageBuilder ConfigureLogger(MessageLogger logger)
        {
            _messageLogger = logger;
            return this;
        }


        public StateFulDefaultUsageBuilder ConfigureEntry(EntryMiddleware entryMiddleware)
        {

            _entryMiddleware = entryMiddleware;
            return this;
        }

        public Tservice Build<Tservice>()
        {
            if (_statefulServiceContext == null) throw new ArgumentNullException("No StatefulServiceContext setted");

            if (_messageLogger == null) throw new ArgumentNullException("No messageLogger setted");

            if (_entryMiddleware == null) throw new ArgumentNullException("No entryMiddleware setted");

            var builder = new FollowingBuilder();

            _entryMiddleware(builder);

            return  (Tservice)Activator.CreateInstance(
                typeof(Tservice),
                _statefulServiceContext, 
                new ServiceEvent(_messageLogger),
                builder.FollowingBuild<FollowingUsage>());
        }
    }
}
