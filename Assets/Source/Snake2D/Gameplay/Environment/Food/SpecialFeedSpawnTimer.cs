using System.Diagnostics;
using UnityEngine;

namespace Snake2D.Gameplay.Environment.Food {

    public class SpecialFeedSpawnTimer {

        /// <summary>
        /// Counts when spawn new special feed.
        /// </summary>
        private Stopwatch _timer = new Stopwatch();

        /// <summary>
        /// Seconds to spawn feed after last feed expired.
        /// </summary>
        private float _nextSpawnTimeSeconds;

        /// <summary>
        /// Restarts timer and randomize new _nextSpawnTimeSeconds value.
        /// </summary>
        public void Restart(Vector2 range) {
            _nextSpawnTimeSeconds = UnityEngine.Random.Range(range.x, range.y);
            _timer.Reset();
            _timer.Start();
        }

        /// <summary>
        /// Checks this is time to spawn new feed.
        /// </summary>
        public bool HasElapsedTime() {
            return _timer.Elapsed.Seconds >= _nextSpawnTimeSeconds;
        }

        /// <summary>
        /// Resets and stops timer.
        /// </summary>
        public void Stop() {
            _timer.Reset();
        }

    }

}
