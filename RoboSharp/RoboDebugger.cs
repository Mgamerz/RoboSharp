using System;

namespace RoboSharp
{
    public sealed class RoboDebugger
    {
        private static readonly Lazy<RoboDebugger> instance = new Lazy<RoboDebugger>(() => new RoboDebugger());

        private RoboDebugger()
        {

        }

        public static RoboDebugger Instance
        {
            get { return instance.Value; }
        }

        public EventHandler<DebugMessageArgs> DebugMessageEvent;

        public class DebugMessageArgs : EventArgs
        {
            public object Message { get; set; }
        }

        private void RaiseDebugMessageEvent(object message)
        {
            DebugMessageEvent?.Invoke(this, new DebugMessageArgs
            {
                Message = message
            });
        }

        internal void DebugMessage(object data)
        {
            RaiseDebugMessageEvent(data);
        }
    }
}
