using Core.Common;
using Core.Object;
using UnityEngine;

namespace Core.UI
{
    public abstract class UiController : UnityObject, IController {

        /// <summary>
        /// Called once after construction.
        /// </summary>
        public virtual void OnStart() {}

        /// <summary>
        /// Called every frame.
        /// </summary>
        public virtual void Update() {}

        /// <summary>
        /// Factory method. Gets game object with Canvas component from scene.
        /// </summary>
        protected override GameObject MakeGameObject() {
            return GameObject.FindObjectOfType<Canvas>().gameObject;
        }
    }
}
