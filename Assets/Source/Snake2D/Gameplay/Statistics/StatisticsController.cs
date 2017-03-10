using System;
using Core.Event;
using Core.Scripts;
using Snake2D.Gameplay.Environment.Food;
using Core.Common;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Statistics {

    public class StatisticsController : IController, IEventParticipant {

        /// <summary>
        /// Reference to eventController.
        /// </summary>
        private IEventController _eventController;

        /// <summary>
        /// Score gathered by player.
        /// </summary>
        public static int score { get; private set; }

        /// <summary>
        /// Init score to zero and subscribes events.
        /// </summary>
        public void OnStart() {
            score = 0;
            Subscribe(UnityScene.GetController<EventController>());
        }

        /// <summary>
        /// Set reference to event controller and listener to FeedEatenEvent.
        /// </summary>
        public void Subscribe(IEventController eventController) {
            eventController.AddListener<FeedEatenEvent>(OnFeedEaten);
            _eventController = eventController;
        }

        /// <summary>
        /// Adds score points when snake has eaten feed.
        /// </summary>
        private void OnFeedEaten(EventArgs args) {
            FeedEatenEventArgs feedArgs = args as FeedEatenEventArgs;
            
            if (feedArgs.eatenFeedType == typeof(NormalFeed))
                score += 1;
            else if (feedArgs.eatenFeedType == typeof(SpecialFeed))
                score += 10;

            _eventController.Dispatch<ScoreChangedEvent>(new ScoreChangedEventArgs(score));
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        public void Update() {}

    }

}
