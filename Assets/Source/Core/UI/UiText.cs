using Core.Object;
using UnityEngine.UI;

namespace Core.UI {

    public abstract class UiText : UnityObject {

        /// <summary>
        /// Reference to text component of game object.
        /// </summary>
        public Text textComponent { get; private set; }

        /// <summary>
        /// Constructor. Sets text component reference of a the text.
        /// </summary>
        public UiText() {
            textComponent = go.GetComponent<Text>();
        }

    }

}
