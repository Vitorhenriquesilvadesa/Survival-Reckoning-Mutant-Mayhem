using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics.Event
{
    public class EventDispatcher : MonoBehaviour
    {
        public static EventDispatcher Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<EventDispatcher>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject("EventDispatcher");
                        _instance = obj.AddComponent<EventDispatcher>();
                    }
                }
                return _instance;
            }
        }
        
        private static EventDispatcher _instance;
        
        private Dictionary<Type, List<Action<object>>> listeners = new();
        
        
        private EventDispatcher() {}

        public void RegisterListener<T>(Action<T> listener) where T : ActionEvent
        {
            Type eventType = typeof(T);
            if (!listeners.ContainsKey(eventType))
            {
                listeners[eventType] = new List<Action<object>>();
            }
            listeners[eventType].Add(e => listener(e as T));
        }
        
        public void Emit<T>(T eventInstance) where T : ActionEvent
        {
            Type eventType = eventInstance.GetType();
            
            if (listeners.ContainsKey(eventType))
            {
                foreach (var listener in listeners[eventType])
                {
                    listener(eventInstance);
                }
            }
        }
    }
}