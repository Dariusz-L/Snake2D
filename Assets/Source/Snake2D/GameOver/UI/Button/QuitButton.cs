using Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Snake2D.GameOver.UI.Button {

    public class QuitButton : UiButton {

        /// <summary>
        /// When one clicks button then menu scene is loaded.
        /// </summary>
        protected override void OnPointerClick(PointerEventData data) {
            SceneManager.LoadScene("MenuScene");
        }

        /// <summary>
        /// Factory method. Looks for quit button in a scene.
        /// </summary>
        protected override GameObject MakeGameObject() {
            return GameObject.Find("QuitButton");
        }

    }

}
