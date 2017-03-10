using Core.Scripts.Resource;
using UnityEngine;

namespace Snake2D.Gameplay.Resource {

    public class Snake2DResourceData : ResourceData {

        /// <summary>
        /// Responsible for snake speed.
        /// </summary>
        public float snakeMoveDelaySeconds;

        /// <summary>
        /// Reference to snake tile prefab.
        /// </summary>
        public GameObject PREFAB_SNAKE_TILE;

        /// <summary>
        /// Reference to normal feed prefab.
        /// </summary>
        public GameObject PREFAB_NORMAL_FEED;

        /// <summary>
        /// Reference to special feed prefab.
        /// </summary>
        public GameObject PREFAB_SPECIAL_FEED;

    }
}
