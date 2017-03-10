using Core.Scripts;
using Core.Event;
using Snake2D.Gameplay.Environment;
using Snake2D.Gameplay.Environment.Food;
using Snake2D.Gameplay.Snake;
using Core.Common;
using Snake2D.Gameplay.View;

namespace Snake2D.Gameplay {

    public class GameController : IController {

        /// <summary>
        /// Floor
        /// </summary>
        private Floor _floor;

        /// <summary>
        /// Responsible for spawning food
        /// </summary>
        public FeedSpawningController foodSpawningController { get; private set; } 

        /// <summary>
        /// Responsible for all of snake
        /// </summary>
        private SnakeController _snakeController;

        /// <summary>
        /// Responsible for camera.
        /// </summary>
        private IController _cameraController;

        /// <summary>
        /// Contructor. Inits floor, snake parts, camera controller and move controller.
        /// </summary>
        public GameController() {
            _floor = new Floor();
            foodSpawningController = new FeedSpawningController(_floor);
            _snakeController = new SnakeController(_floor);
            _cameraController = new CameraController();
        }

        /// <summary>
        /// Called once after constructor
        /// </summary>
        public void OnStart() {
            _snakeController.OnStart();
            _cameraController.OnStart();
            foodSpawningController.OnStart();

            IEventController e = UnityScene.GetController<EventController>();
            foodSpawningController.Subscribe(e);
        }
        
        /// <summary>
        /// Called every frame
        /// </summary>
        public void Update() {
            _snakeController.Update();
            foodSpawningController.Update();
        }
    }

}
