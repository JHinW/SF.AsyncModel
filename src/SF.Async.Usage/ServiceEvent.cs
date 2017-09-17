using SF.Async.Core;
using System.Diagnostics.Tracing;
using static SF.Async.Core.Delegates;

namespace SF.Async.Usage
{
    public class ServiceEvent: EventSource, IServiceEvent
    {
        private MessageLogger _messageLogger;

        public ServiceEvent(EventSource eventSource)
        {
            _messageLogger = log =>
            {
                this.WriteEvent(1, log);
            };
        }

        public ServiceEvent(MessageLogger messageLogger)
        {
            _messageLogger = messageLogger;
        }

        public void LogEvents(string log)
        {
            _messageLogger(log);
        }

          
    }
}
