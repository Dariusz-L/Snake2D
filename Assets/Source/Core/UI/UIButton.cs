using Core.Object;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Core.UI {

    public abstract class UiButton : UnityObject {

        /// <summary>
        /// Unity EventTrigger for ui events
        /// </summary>
        private EventTrigger _trigger;

        /// <summary>
        /// Constructor. Inits trigger event - adds pointer click handler.
        /// </summary>
        public UiButton() {
            _trigger = go.AddComponent<EventTrigger>();
            AddEntryToTrigger<PointerEventData>(_trigger, EventTriggerType.PointerClick, OnPointerClick);
        }
        
        /// <summary>
        /// Called when one clicks on button.
        /// </summary>
        /// <param name="data"></param>
        protected virtual void OnPointerClick(PointerEventData data) {}

        /// <summary>
        /// Adds event handler.
        /// </summary>
        void AddEntryToTrigger<T>(EventTrigger trigger, EventTriggerType type, UnityAction<T> call) where T : BaseEventData {
            UnityAction<T> a = call;

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = type;
            entry.callback.AddListener((data) => {call ((T) data); });
            trigger.triggers.Add(entry);
        }
    }
}
