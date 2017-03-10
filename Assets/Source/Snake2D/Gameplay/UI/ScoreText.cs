using Core.UI;
using Core.Event;
using UnityEngine;
using System;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.UI {

    public class ScoreText : UiText, IEventParticipant {

        /// <summary>
        /// Called when player's score changes.
        /// </summary>
        /// <param name="score"></param>
        private void OnScoreChanged(EventArgs args) {
            var scoreEvent = args as ScoreChangedEventArgs;
            textComponent.text = "Score: " + scoreEvent.score;
        }

        /// <summary>
        /// Gets score text from scene.
        /// </summary>
        /// <returns></returns>
        protected override GameObject MakeGameObject() {
            return GameObject.Find("ScoreText");
        }

        /// <summary>
        /// Adds OnScoreChanged method for listening to event. 
        /// </summary>
        /// <param name="eventController"></param>
        public void Subscribe(IEventController eventController) {
            eventController.AddListener<ScoreChangedEvent>(OnScoreChanged);
        }
    }
}
