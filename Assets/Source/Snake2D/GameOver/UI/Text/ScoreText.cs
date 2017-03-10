using Core.UI;
using Snake2D.Gameplay.Statistics;
using UnityEngine;

namespace Snake2D.GameOver.UI.Text {

    public class ScoreText : UiText {

        /// <summary>
        /// Constructor. Sets score text and value.
        /// </summary>
        public ScoreText() {
            textComponent.text = "Score: " + StatisticsController.score;
        }

        /// <summary>
        /// Factory method. Gets score text from scene.
        /// </summary>
        protected override GameObject MakeGameObject() {
            return GameObject.Find("ScoreText");
        }

    }
}
