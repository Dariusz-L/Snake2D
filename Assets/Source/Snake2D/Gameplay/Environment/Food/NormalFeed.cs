using Core.Scripts;
using Snake2D.Gameplay.Resource;
using UnityEngine;

namespace Snake2D.Gameplay.Environment.Food {

    public class NormalFeed : Feed {

        /// <summary>
        /// Constructor. Sends init position to base contructor.
        /// </summary>
        public NormalFeed(Vector2 pos) : base (pos) {}

        /// <summary>
        /// Called every frame.
        /// </summary>
        public void Update() {}

        /// <summary>
        /// Factory method. Instantiates normal food prefab.
        /// </summary>
        protected override GameObject MakeGameObject() {
            var resourceData = UnityScene.GetResourceManager().resourceData as Snake2DResourceData;
            return MonoBehaviour.Instantiate(resourceData.PREFAB_NORMAL_FEED);
        }

    }

}
