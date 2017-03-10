using Core;
using Core.Event;
using Snake2D.Gameplay.Input;
using Snake2D.Gameplay.Statistics;
using Snake2D.Gameplay.UI;

namespace Snake2D.Gameplay {

    public class GameplaySceneController : MainController {

        /// <summary>
        /// Constructor. Adds controllers of scene.
        /// </summary>
        public GameplaySceneController() {
            AddController(new EventController());
            AddController(new GameplayUiController());
            AddController(new GameController());
            AddController(new SnakeInputController());
            AddController(new StatisticsController());
        }

    }
}
