using Snake2D.Gameplay.Snake.Move;
using System;
using UnityEngine.Events;

namespace Snake2D.Gameplay.Event {

    public class SnakeTurnCommandArgs : EventArgs {

        /// <summary>
        /// Turn command.
        /// </summary>
        public SnakeTurnCommand turnCommand { get; private set; }

        /// <summary>
        /// Constructor. Sets turnCommand.
        /// </summary>
        public SnakeTurnCommandArgs(SnakeTurnCommand turnCommand) {
            this.turnCommand = turnCommand;
        }
    }

    public class SnakeTurnCommandEvent : UnityEvent<EventArgs> {}

}