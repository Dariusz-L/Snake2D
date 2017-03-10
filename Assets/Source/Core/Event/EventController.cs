using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Core.Event {

    public class EventController : IEventController {

        /// <summary>
        /// Stores all events and methods.
        /// </summary>
        private IDictionary<Type, UnityEvent<EventArgs>> _events;

        public EventController() {
            _events = new Dictionary<Type, UnityEvent<EventArgs>>();
        }

        /// <summary>
        /// Called once after construction.
        /// </summary>
        public void OnStart() {}

        /// <summary>
        /// Adds method to event of given type.
        /// </summary>
        public void AddListener<T>(UnityAction<EventArgs> method) where T : UnityEvent<EventArgs>, new() {
            Type t = typeof(T);
            UnityEvent<EventArgs> e;
            _events.TryGetValue(t, out e);

            if (e == null) {
                e = new T();
                _events.Add(t, e);
            }

            e.AddListener(method);
        }

        /// <summary>
        /// Removes method from listeners of given event type.
        /// </summary>
        public void RemoveListener<T>(UnityAction<EventArgs> method) where T : UnityEvent<EventArgs>, new() {
            Type t = typeof(T);

            UnityEvent<EventArgs> e;
            _events.TryGetValue(t, out e);

            if (e != null)
                e.RemoveListener(method);
        }

        /// <summary>
        /// Call all methods listening to given event.
        /// </summary>
        public void Dispatch<T>(EventArgs args) where T : UnityEvent<EventArgs> {
            Type t = typeof(T);
            UnityEvent<EventArgs> e = _events[t];
            e.Invoke(args);
        }

        /// <summary>
        /// Removes all subscribed events
        /// </summary>
        public void Clear() {
            _events.Clear();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        public void Update() {}

    }
}
