using System;
using System.Collections.Generic;

namespace ID5D6AAC.Common.EventDispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private Dictionary<string, List<Action>> _subscriptionsNoParameters;
        private Dictionary<string, List<IEventhandlerWithParameter>> _subscriptionsWithParameters;

        public EventDispatcher()
        {
            _subscriptionsNoParameters = new Dictionary<string, List<Action>>();
            _subscriptionsWithParameters = new Dictionary<string, List<IEventhandlerWithParameter>>();
        }

        public void AddEventListener(string EventType, Action handler)
        {
            if (!_subscriptionsNoParameters.ContainsKey(EventType))
            {
                _subscriptionsNoParameters[EventType] = new List<Action>();
            }

            _subscriptionsNoParameters[EventType].Add(handler);
        }

        public void AddEventListener<TData>(string EventType, Action<TData> handler)
        {
            if (!_subscriptionsWithParameters.ContainsKey(EventType))
            {
                _subscriptionsWithParameters[EventType] = new List<IEventhandlerWithParameter>();
            }

            EventhandlerWithParameter<TData> eventhandler = new EventhandlerWithParameter<TData>(handler);
            _subscriptionsWithParameters[EventType].Add(eventhandler);
        }

        public void DispatchEvent(string EventType)
        {
            if (_subscriptionsNoParameters.ContainsKey(EventType))
            {
                _subscriptionsNoParameters[EventType].ForEach(a => a.Invoke());
            }
        }

        public void DispatchEvent<TData>(string EventType, TData data)
        {
            EventhandlerWithParameter<TData> eventhandlerWithParameter;
            if (_subscriptionsWithParameters.ContainsKey(EventType))
            {
                _subscriptionsWithParameters[EventType].ForEach(eventHandler =>
                    {
                        eventhandlerWithParameter = eventHandler as EventhandlerWithParameter<TData>;
                        eventhandlerWithParameter.Data = data;
                        eventHandler.Invoke();
                    });
            }
        }
        
        private class EventhandlerWithParameter<TData> : IEventhandlerWithParameter
        {
            private Action<TData> _handler;
            private TData _data;

            public TData Data
            {
                get => _data;
                set => _data = value;
            }

            public EventhandlerWithParameter(Action<TData> handler)
            {
                _handler = handler;
            }

            public void Invoke()
            {
                _handler.Invoke(_data);
            }
        }
        
        private interface IEventhandlerWithParameter
        {
            void Invoke();
        }
    }


}