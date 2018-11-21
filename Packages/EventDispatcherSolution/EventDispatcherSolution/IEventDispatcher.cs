using System;

namespace ID5D6AAC.EventDispatcher
{
    public interface IEventDispatcher
    {
        void AddEventListener(string EventType, Action handler);
        void AddEventListener<TData>(string EventType, Action<TData> handler);
        void DispatchEvent(string EventType);
        void DispatchEvent<TData>(string EventType, TData data);
    }
}