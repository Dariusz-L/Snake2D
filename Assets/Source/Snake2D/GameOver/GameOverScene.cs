using Core;
using Core.Scripts;

namespace Snake2D.GameOver {

    public class GameOverScene : UnityScene {

        /// <summary>
        /// Creates IGameController instance.
        /// </summary>
        /// <returns></returns>
        protected override IMainController MakeMainController() {
            return new GameOverSceneController();
        }

    }

}
