using Core.Scripts.Resource;
using UnityEngine;

namespace Snake2D.Gameplay.Resource {

    public class Snake2DResourceManager : ResourceManager {

        /// <summary>
        /// Factory method. Looks for Snake2DResourceData script in the scene.
        /// </summary>
        protected override ResourceData MakeResourceData() {
            return GameObject.FindObjectOfType<Snake2DResourceData>();
        }

    }

}
