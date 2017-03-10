using Snake2D.Gameplay.Snake.Body;
using System;
using UnityEngine.Events;

namespace Snake2D.Gameplay.Event {

    public class SnakeMoveEventArgs : EventArgs {

        /// <summary>
        /// Reference to snakeParts.
        /// </summary>
        public SnakeParts snakeParts { get; private set; }

        /// <summary>
        /// Constructor. Set snakeParts reference.
        /// </summary>
        public SnakeMoveEventArgs(SnakeParts snakeParts) {
            this.snakeParts = snakeParts;
        }
    }

    public class SnakeMoveEvent : UnityEvent<EventArgs> {}

}