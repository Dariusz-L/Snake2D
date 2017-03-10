using Snake2D.Gameplay.Snake.Move;
using Snake2D.Gameplay.Snake.Body;
using Core.Event;
using Core.Scripts;
using Snake2D.Gameplay.Environment;
using Core.Common;

namespace Snake2D.Gameplay.Snake {

    public class SnakeController : IController {

        /// <summary>
        /// Contains references to snake's parts gameobjects in the scene.
        /// </summary>
        private SnakeParts _parts;

        /// <summary>
        /// Responsible for snake movement
        /// </summary>
        private SnakeMoveController _moveController;

        /// <summary>
        /// Responsible for eating
        /// </summary>
        private IEventParticipant _snakeEatingSystem;

        /// <summary>
        /// Responsible for growing.
        /// </summary>
        private IEventParticipant _snakeGrowingSystem;

        /// <summary>
        /// Responsible for collision with snake and walls.
        /// </summary>
        private IEventParticipant _snakeCollisionController;

        /// <summary>
        /// Constructor. Creates instances.
        /// </summary>
        public SnakeController(Floor floor) {
            _parts = new SnakeParts();
            _moveController = new SnakeMoveController(_parts);
            _snakeEatingSystem = new SnakeEatingController(_parts);
            _snakeGrowingSystem = new SnakeGrowingController(_parts);
            _snakeCollisionController = new SnakeCollisionController(_parts, floor);
        }

        /// <summary>
        /// Subscribes events and init parts and moveController.
        /// </summary>
        public void OnStart() {
            _moveController.OnStart();
            _parts.OnStart();

            IEventController e = UnityScene.GetController<EventController>();
            _moveController.Subscribe(e);
            _snakeEatingSystem.Subscribe(e);
            _snakeGrowingSystem.Subscribe(e);
            _snakeCollisionController.Subscribe(e);
        }

        /// <summary>
        /// Updates moveController.
        /// </summary>
        public void Update() {
            _moveController.Update();
        }
    }
}
