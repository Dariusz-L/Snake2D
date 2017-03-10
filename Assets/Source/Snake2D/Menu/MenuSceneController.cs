using Core;
using Snake2D.Menu.UI;

namespace Snake2D.Menu {

    public class MenuSceneController : MainController {

        /// <summary>
        /// Constructor. Adds controllers of scene.
        /// </summary>
        public MenuSceneController() {
            AddController(new MenuUiController());
        }

    }
}