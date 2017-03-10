using System;
using Core.Event;
using UnityEngine;
using Core.Common;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Environment.Food {

    public class FeedSpawningController : IController, IEventParticipant {

        /// <summary>
        /// Reference to event controller.
        /// </summary>
        private IEventController _eventController;

        /// <summary>
        /// If is not on screen then null.
        /// </summary>
        private SpecialFeed _actualSpecialFeed;

        /// <summary>
        /// Reference to normal feed
        /// </summary>
        private NormalFeed _actualNormalFeed;

        /// <summary>
        /// Responsible for specialfede spawn counting.
        /// </summary>
        private SpecialFeedSpawnTimer _specialFeedSpawnTimer;

        /// <summary>
        /// Reference to floor.
        /// </summary>
        private Floor _floor;

        /// <summary>
        /// Contructor. Sets reference to floor and creates instance of _specialFeedSpawnTimer;
        /// </summary>
        public FeedSpawningController(Floor floor) {
            _floor = floor;
            _specialFeedSpawnTimer = new SpecialFeedSpawnTimer();
        }

        /// <summary>
        /// Start special feed spawn timer.
        /// </summary>
        public void OnStart() {
            _specialFeedSpawnTimer.Restart(SpecialFeed.SPAWN_TIME_RANGE_SECONDS);
        }

        /// <summary>
        /// Sets event controller reference and adds events listeners.
        /// </summary>
        public void Subscribe(IEventController eventController) {
            eventController.AddListener<SpecialFeedExpiredEvent>(OnSpecialFeedExpired);
            eventController.AddListener<FeedEatenEvent>(OnFeedEaten);
            eventController.AddListener<SnakeMoveEvent>(OnSnakeMoveEvent);

            _eventController = eventController;
        }

        /// <summary>
        /// Checks if feed is near snake head.
        /// </summary>
        public Type IsFeedAvailable(Vector2 headPos) {
            if (_actualNormalFeed != null && (Vector2) _actualNormalFeed.transform.position == headPos)
                return typeof(NormalFeed);
            if (_actualSpecialFeed != null && (Vector2) _actualSpecialFeed.transform.position == headPos)
                return typeof(SpecialFeed);

            return null;
        }

        /// <summary>
        /// Called only once. Spawns first normal feed.
        /// </summary>
        private void OnSnakeMoveEvent(EventArgs args) {
            SpawnNormalFeed();
            _eventController.RemoveListener<SnakeMoveEvent>(OnSnakeMoveEvent);
        }

        /// <summary>
        /// If snake has eaten normal feed then spawn new normal feed.
        /// If snake has eaten special feed restart special feed spawn timer.
        /// </summary>
        private void OnFeedEaten(EventArgs args) {
            FeedEatenEventArgs feedArgs = args as FeedEatenEventArgs;

            if (feedArgs.eatenFeedType == typeof(NormalFeed)) {
                SpawnNormalFeed();
            } else if (feedArgs.eatenFeedType == typeof(SpecialFeed)) {
                OnSpecialFeedExpired(null);
            }
        }

        /// <summary>
        /// Restarts special feed spawn timer when last special feed expired.
        /// </summary>
        private void OnSpecialFeedExpired(EventArgs args) {
            _actualSpecialFeed.Reset();
            _actualSpecialFeed = null;

            _specialFeedSpawnTimer.Restart(SpecialFeed.SPAWN_TIME_RANGE_SECONDS);
        }

        /// <summary>
        /// Updates special feed if is spawned and checks if special feed should spawned.
        /// </summary>
        public void Update() {
            if (_actualSpecialFeed != null)
                _actualSpecialFeed.Update();

            if (_specialFeedSpawnTimer.HasElapsedTime()) {
                _specialFeedSpawnTimer.Stop();
                SpawnSpecialFeed();
            }
        }

        /// <summary>
        /// Spawns special feed.
        /// </summary>
        private void SpawnSpecialFeed() {
            _actualSpecialFeed = new SpecialFeed(_floor.GetRandomTilePosition());
        }

        /// <summary>
        /// Spawns noral feed.
        /// </summary>
        private void SpawnNormalFeed() {
            if (_actualNormalFeed != null)
                _actualNormalFeed.Reset();

            _actualNormalFeed = new NormalFeed(_floor.GetRandomTilePosition());
        }
    }

}
