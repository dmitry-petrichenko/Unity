using System;
using System.Collections.Generic;

namespace ID5D6AAC.Common.EventDispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private Dictionary<string, List<Action>> _subscriptionsNoParameters;
        private Dictionary<string, Dictionary<Delegate, IEventhandlerWithParameter>> _subscriptionsWithParameters;

        public EventDispatcher()
        {
            _subscriptionsNoParameters = new Dictionary<string, List<Action>>();
            _subscriptionsWithParameters = new Dictionary<string, Dictionary<Delegate, IEventhandlerWithParameter>>();
        }

        public void AddEventListener(string eventType, Action handler)
        {
            if (!_subscriptionsNoParameters.ContainsKey(eventType))
            {
                _subscriptionsNoParameters[eventType] = new List<Action>();
            }

            _subscriptionsNoParameters[eventType].Add(handler);
        }

        public void AddEventListener<TData>(string eventType, Action<TData> handler)
        {
            if (!_subscriptionsWithParameters.ContainsKey(eventType))
            {
                _subscriptionsWithParameters[eventType] = new Dictionary<Delegate, IEventhandlerWithParameter>();
            }

            EventhandlerWithParameter<TData> eventhandler = new EventhandlerWithParameter<TData>(handler);
            _subscriptionsWithParameters[eventType].Add(handler, eventhandler);
        }

        public void DispatchEvent(string eventType)
        {
            if (_subscriptionsNoParameters.ContainsKey(eventType))
            {
                _subscriptionsNoParameters[eventType].ForEach(a => a.Invoke());
            }
        }

        public void DispatchEvent<TData>(string eventType, TData data)
        {
            EventhandlerWithParameter<TData> eventhandlerWithParameter;
            if (_subscriptionsWithParameters.ContainsKey(eventType))
            {
                foreach(KeyValuePair<Delegate, IEventhandlerWithParameter> item in _subscriptionsWithParameters[eventType])
                {
                    eventhandlerWithParameter = item.Value as EventhandlerWithParameter<TData>;
                    eventhandlerWithParameter.Data = data;
                    eventhandlerWithParameter.Invoke();
                }
            }
        }

        public void RemoveEventListener(string eventType, Delegate handler)
        {
            if (_subscriptionsWithParameters.ContainsKey(eventType))
            {
                if (_subscriptionsWithParameters[eventType].ContainsKey(handler))
                {
                    _subscriptionsWithParameters[eventType].Remove(handler);
                }
            }

            Action action = handler as Action;
            if (_subscriptionsNoParameters.ContainsKey(eventType))
            {
                if (_subscriptionsNoParameters[eventType].Contains(action))
                {
                    _subscriptionsNoParameters[eventType].Remove(action);
                }
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