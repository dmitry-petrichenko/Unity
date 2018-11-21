using System;

namespace ID5D6AAC.EventDispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        public void AddEventListener(string EventType, Action missing_name)
        {
            throw new NotImplementedException();
        }

        public void AddEventListener<TData>(string EventType, Action<TData> handler)
        {
            throw new NotImplementedException();
        }

        public void DispatchEvent(string EventType)
        {
            throw new NotImplementedException();
        }

        public void DispatchEvent<TData>(string EventType, TData data)
        {
            throw new NotImplementedException();
        }
    }
}