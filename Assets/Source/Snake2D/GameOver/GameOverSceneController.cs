using Core;
using Snake2D.GameOver.UI;

namespace Snake2D.GameOver {

    public class GameOverSceneController : MainController {

        public GameOverSceneController() {
            AddController(new GameOverUIController());
        }

    }

}
