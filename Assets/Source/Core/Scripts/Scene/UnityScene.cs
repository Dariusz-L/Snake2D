using Core.Common;
using Core.Scripts.Resource;
using UnityEngine;

namespace Core.Scripts {

    public abstract class UnityScene : MonoBehaviour {

        /// <summary>
        /// Contains logic.
        /// </summary>
        public IMainController mainController { get; private set; }

        /// <summary>
        /// Contains prefabs and data.
        /// </summary>
        public IResourceManager resourceManager { get; private set; }

        private void Awake() {
            resourceManager = MakeResourceManager();
            mainController = MakeMainController();

            mainController.OnStart();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update() {
            if (mainController != null)
                mainController.Update();
        }
        
        /// <summary>
        /// Factory method. Should be overriden to set IMainController instance;
        /// </summary>
        /// <returns></returns>
        protected virtual IMainController MakeMainController() {
            return null;
        }

        /// <summary>
        /// Factory method. Should be overriden to set IResourceManager instance;
        /// </summary>
        /// <returns></returns>
        protected virtual IResourceManager MakeResourceManager() {
            return null;
        }

        public static T GetController<T>() where T : IController {
            UnityScene scene = GameObject.FindObjectOfType<UnityScene>();
            IMainController mainController = scene.mainController;
            return mainController.GetController<T>();
        }

        public static IResourceManager GetResourceManager() {
            UnityScene scene = GameObject.FindObjectOfType<UnityScene>();
            return scene.resourceManager;
        }

    }

}