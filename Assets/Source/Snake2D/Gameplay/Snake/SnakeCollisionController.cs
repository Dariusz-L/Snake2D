using Core.Event;
using Snake2D.Gameplay.Snake.Body;
using System;
using UnityEngine.SceneManagement;
using Snake2D.Gameplay.Environment;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Snake {

    public class SnakeCollisionController : IEventParticipant {

        /// <summary>
        /// Reference to snake parts
        /// </summary>
        private SnakeParts _snakeParts;

        /// <summary>
        /// Reference to floor
        /// </summary>
        private Floor _floor;

        /// <summary>
        /// If snake has eaten then snake collision with itself check is omitted.
        /// </summary>
        private bool _feedEaten;

        /// <summary>
        /// Constructor. Aggregates SnakeParts and Floor objects.
        /// </summary>
        public SnakeCollisionController(SnakeParts snakeParts, Floor floor) {
            _snakeParts = snakeParts;
            _floor = floor;
        }

        /// <summary>
        /// Adds SnakeMoveEvent and FeedEatenEvent listeners.
        /// </summary>
        /// <param name="eventController"></param>
        public void Subscribe(IEventController eventController) {
            eventController.AddListener<SnakeMoveEvent>(OnSnakeMove);
            eventController.AddListener<FeedEatenEvent>(OnFeedEaten);
        }

        /// <summary>
        /// If snake has eaten a feed then sets _feedEaten flag true.
        /// </summary>
        /// <param name="args"></param>
        private void OnFeedEaten(EventArgs args) {
            _feedEaten = true;
        }

        /// <summary>
        /// Checks if snake is colliding with itself or with walls. If yes, then loads gameOver scene.
        /// </summary>
        private void OnSnakeMove(EventArgs args) {
            if (CheckCollisionWithSnake(ref _feedEaten) || CheckCollisioWithWalls())
                SceneManager.LoadScene("GameOverScene");
        }

        /// <summary>
        /// Checks if snake is colliding with wall.
        /// </summary>
        private bool CheckCollisioWithWalls() {
            if (!_floor.IsOnTheFloor(_snakeParts.head.transform.position))
                return true;

            return false;
        }

        /// <summary>
        /// Checks if snake is colliding with itself
        /// </summary>
        private bool CheckCollisionWithSnake(ref bool feedEaten) {
            if (!feedEaten) {
                foreach (var p in _snakeParts.tailParts) {
                    if (_snakeParts.head.transform.position == p.transform.position) {
                        return true;
                    }
                }
            } else
                feedEaten = false;

            return false;
        }
    }
}
