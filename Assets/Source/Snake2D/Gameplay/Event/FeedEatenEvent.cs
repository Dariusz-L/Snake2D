using System;
using UnityEngine.Events;

namespace Snake2D.Gameplay.Event {

    public class FeedEatenEventArgs : EventArgs { 
        
        /// <summary>
        /// Type of feed which snake has just eaten.
        /// </summary>
        public Type eatenFeedType { get; private set; }


        /// <summary>
        /// Contructor sets eatenFeedType.
        /// </summary>
        public FeedEatenEventArgs(Type eatenFeedType) {
            this.eatenFeedType = eatenFeedType;
        }
    }

    public class FeedEatenEvent : UnityEvent<EventArgs> {}

}