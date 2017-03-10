using Snake2D.Gameplay.Snake.Body;
using Core.Event;
using System;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Snake {

    public class SnakeGrowingController : IEventParticipant {

        /// <summary>
        /// Reference to snake parts.
        /// </summary>
        private SnakeParts _parts;

        /// <summary>
        /// Contructor. Aggregates snake parts.
        /// </summary>
        public SnakeGrowingController(SnakeParts parts) {
            _parts = parts;
        }

        /// <summary>
        /// Adds FeedEatenEvent listener.
        /// </summary>
        public void Subscribe(IEventController eventController) {
            eventController.AddListener<FeedEatenEvent>(OnFeedEaten);
        }

        /// <summary>
        /// If snake has eaten then grow.
        /// </summary>
        private void OnFeedEaten(EventArgs args) {
            _parts.GrowSnake();
        }
    }
}