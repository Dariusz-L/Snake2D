using Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Snake2D.Menu.UI {

    public class PlayButton : UiButton {

        /// <summary>
        /// When one clicks button then gameplay scene is loaded.
        /// </summary>
        protected override void OnPointerClick(PointerEventData data) {
            SceneManager.LoadScene("GameplayScene");
        }

        /// <summary>
        /// Looks for play button in a scene.
        /// </summary>
        protected override GameObject MakeGameObject() {
            return GameObject.Find("PlayButton");
        }
    }

}
