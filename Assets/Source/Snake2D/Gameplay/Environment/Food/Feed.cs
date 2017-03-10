using Core.Object;
using UnityEngine;

namespace Snake2D.Gameplay.Environment.Food {

    public class Feed : UnityObject {

        /// <summary>
        /// Constructor. Sets position of feed in the scene.
        /// </summary>
        public Feed(Vector2 pos) {
            transform.position = pos;
        }

    }
}
