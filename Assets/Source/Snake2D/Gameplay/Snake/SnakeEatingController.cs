using System;
using Core.Scripts;
using Snake2D.Gameplay.Environment.Food;
using Core.Event;
using Snake2D.Gameplay.Snake.Body;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Snake {

    public class SnakeEatingController : IEventParticipant {

        /// <summary>
        /// Reference to event controller.
        /// </summary>
        private IEventController _eventController;

        /// <summary>
        /// Reference to _foodSpawningController;
        /// </summary>
        private FeedSpawningController _foodSpawningController;

        /// <summary>
        /// Reference to snake parts.
        /// </summary>
        private SnakeParts _snakeParts;

        /// <summary>
        /// Constructor. Aggregates snake parts.
        /// </summary>
        public SnakeEatingController(SnakeParts snakeParts) {
            _snakeParts = snakeParts;
        }

        /// <summary>
        /// Sets _foodSpawningController and event controller reference. Adds SnakeMoveEvent listener.
        /// </summary>
        public void Subscribe(IEventController eventController) {
            _foodSpawningController = UnityScene.GetController<GameController>().foodSpawningController;
            eventController.AddListener<SnakeMoveEvent>(OnSnakeMove);
            _eventController = eventController;
        }

        /// <summary>
        /// If snake moves then check is feed is near. If yes then dispatch FeedEatenEvent.
        /// </summary>
        private void OnSnakeMove(EventArgs args) {
            Type type = _foodSpawningController.IsFeedAvailable(_snakeParts.head.transform.position);

            if (type == null)
                return;

            _eventController.Dispatch<FeedEatenEvent>(new FeedEatenEventArgs(type));
        }
    }

}