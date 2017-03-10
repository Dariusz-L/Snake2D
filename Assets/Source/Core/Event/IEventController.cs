using Core.Common;
using System;
using UnityEngine.Events;

namespace Core.Event {

    public interface IEventController : IController {

        /// <summary>
        /// Adds method to event of given type.
        /// </summary>
        void AddListener<T>(UnityAction<EventArgs> method) where T : UnityEvent<EventArgs>, new();

        /// <summary>
        /// Removes method from listeners of given event type.
        /// </summary>
        void RemoveListener<T>(UnityAction<EventArgs> method) where T : UnityEvent<EventArgs>, new();

        /// <summary>
        /// Dispatches given event.
        /// </summary>
        void Dispatch<T>(EventArgs args) where T : UnityEvent<EventArgs>;

        /// <summary>
        /// Removes all subscribed events
        /// </summary>
        void Clear();

    }
}
