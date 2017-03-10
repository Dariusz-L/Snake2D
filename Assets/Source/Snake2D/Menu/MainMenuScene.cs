using Core;
using Core.Scripts;

namespace Snake2D.Menu {

    public class MainMenuScene : UnityScene {

        /// <summary>
        /// Creates IGameController instance.
        /// </summary>
        /// <returns></returns>
        protected override IMainController MakeMainController() {
            return new MenuSceneController();
        }

    }

}
