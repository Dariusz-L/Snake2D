using Core.Scripts;
using Snake2D.Gameplay.Resource;
using System.Collections.Generic;
using UnityEngine;

namespace Snake2D.Gameplay.Snake.Body {

    public class SnakeParts {

        /// <summary>
        /// Reference to head tile in a scene
        /// </summary>
        public GameObject head { get; private set; }

        /// <summary>
        /// List of references to tail parts of the snake.
        /// </summary>
        public IList<GameObject> tailParts { get; private set; }

        /// <summary>
        /// Constructor. Creates instance of tailParts list.
        /// </summary>
        public SnakeParts() {
            tailParts = new List<GameObject>();
        }

        /// <summary>
        /// Inits head and tailparts list.
        /// </summary>
        public void OnStart() {
            InitHead();
            InitTailPartsList();
        }

        /// <summary>
        /// Looks for head object in the scene.
        /// </summary>
        private void InitHead() {
            head = GameObject.Find("SnakeHead");
        }

        /// <summary>
        /// Looks for tail parts objects in the scene.
        /// </summary>
        private void InitTailPartsList() {
            foreach (Transform tr in GameObject.Find("Snake").transform)
                if (tr.name != "SnakeHead")
                    tailParts.Add(tr.gameObject);
        }

        /// <summary>
        /// Instantiate new part of tail and attaches it to snake tail parts.
        /// </summary>
        public void GrowSnake() {
            var resourceData = UnityScene.GetResourceManager().resourceData as Snake2DResourceData;
            GameObject newSnakeTile = MonoBehaviour.Instantiate(resourceData.PREFAB_SNAKE_TILE);
            newSnakeTile.transform.position = head.transform.position;
            tailParts.Insert(0, newSnakeTile);
        }
    }

}
