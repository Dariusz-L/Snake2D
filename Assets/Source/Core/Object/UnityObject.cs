using UnityEngine;

namespace Core.Object
{
    public abstract class UnityObject
    {
        /// <summary>
        /// Contains reference to game object
        /// </summary>
        public GameObject go { get; protected set; }

        /// <summary>
        /// Contains reference to transform of game object
        /// </summary>
        public Transform transform { get; private set; }

        /// <summary>
        /// Should be overriden in child class to access reference to game object.
        /// </summary>
        /// <returns></returns>
        protected virtual GameObject MakeGameObject() {
            return null;
        }

        /// <summary>
        /// Resets objects.
        /// </summary>
        public virtual void Reset() {
            if (go != null) {
                MonoBehaviour.Destroy(go);
                transform = null;
            }
        }

        /// <summary>
        /// Constructor. Inits game object and transform fields.
        /// </summary>
        public UnityObject() {
            go = MakeGameObject();
            transform = go.transform;
        }
    }
}
