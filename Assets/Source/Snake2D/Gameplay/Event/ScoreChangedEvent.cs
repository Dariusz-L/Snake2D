using System;
using UnityEngine.Events;

namespace Snake2D.Gameplay.Event {

    public class ScoreChangedEventArgs : EventArgs {

        /// <summary>
        /// Actual score of player.
        /// </summary>
        public int score { get; private set; }

        /// <summary>
        /// Contructor. Sets score.
        /// </summary>
        public ScoreChangedEventArgs(int score) {
            this.score = score;
        }
    }

    public class ScoreChangedEvent : UnityEvent<EventArgs> {}
}
