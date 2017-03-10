using Core;
using Core.Scripts;
using Core.Scripts.Resource;
using Snake2D.Gameplay.Resource;

namespace Snake2D.Gameplay {

    public class GameplayScene : UnityScene {

        /// <summary>
        /// Factory method. Creates IMainController instance.
        /// </summary>
        protected override IMainController MakeMainController() {
            return new GameplaySceneController();
        }

        /// <summary>
        /// Factory method. Creates IResourceManager instance.
        /// </summary>
        protected override IResourceManager MakeResourceManager() {
            return new Snake2DResourceManager();
        }

    }

}
