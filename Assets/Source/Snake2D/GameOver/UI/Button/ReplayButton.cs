using Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Snake2D.GameOver.UI.Button {

    public class ReplayButton : UiButton {

        /// <summary>
        /// When one clicks button then gameplay scene is loaded.
        /// </summary>
        /// <param name="data"></param>
        protected override void OnPointerClick(PointerEventData data) {
            SceneManager.LoadScene("GameplayScene");
        }

        /// <summary>
        /// Looks for replay button in a scene.
        /// </summary>
        /// <returns></returns>
        protected override GameObject MakeGameObject() {
            return GameObject.Find("ReplayButton");
        }
    }

}
