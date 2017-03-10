using Core.Event;
using Core.Scripts;
using Core.UI;

namespace Snake2D.Gameplay.UI {

    public class GameplayUiController : UiController {

        /// <summary>
        /// Shows actual score of player.
        /// </summary>
        ScoreText scoreText = new ScoreText();

        /// <summary>
        /// Subscribe scoreText.
        /// </summary>
        public override void OnStart() {
            var ec = UnityScene.GetController<EventController>();
            scoreText.Subscribe(ec);
        }
    }
}
