using Core.UI;
using Snake2D.GameOver.UI.Button;
using Snake2D.GameOver.UI.Text;

namespace Snake2D.GameOver.UI {

    public class GameOverUIController : UiController {

        /// <summary>
        /// Score gathered in game text field.
        /// </summary>
        ScoreText scoreText = new ScoreText();

        /// <summary>
        /// Replay game button field.
        /// </summary>
        ReplayButton replayButton = new ReplayButton();

        /// <summary>
        /// Quit to menu button field
        /// </summary>
        QuitButton quitButton = new QuitButton();
    }
}
