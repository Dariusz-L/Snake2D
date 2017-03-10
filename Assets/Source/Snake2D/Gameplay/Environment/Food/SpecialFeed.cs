using Core.Scripts;
using Snake2D.Gameplay.Resource;
using System.Diagnostics;
using UnityEngine;
using System;
using Core.Event;
using Core.Effect;
using Snake2D.Gameplay.Event;

namespace Snake2D.Gameplay.Environment.Food {

    public class SpecialFeed : Feed {

        /// <summary>
        /// Range of time after which special can be spawned.
        /// </summary>
        public static readonly Vector2 SPAWN_TIME_RANGE_SECONDS = new Vector2(10, 30);

        /// <summary>
        /// Lifetime of special feed in seconds
        /// </summary>
        public const float LIFE_TIME_SECONDS = 10;

        /// <summary>
        /// Time after which feed will start blinking.
        /// </summary>
        public const float BEGIN_BLINK_SECOND = 7;

        /// <summary>
        /// Reference to sprite renderer component
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Makes feed sprite blinking.
        /// </summary>
        private BlinkingEffect _blinkingEffect;

        /// <summary>
        /// Lifetime counter
        /// </summary>
        private Stopwatch _expireStopwatch;

        /// <summary>
        /// Contructor
        /// </summary>
        public SpecialFeed(Vector2 pos) : base (pos) {
            _expireStopwatch = new Stopwatch();
            _expireStopwatch.Start();

            _blinkingEffect = new BlinkingEffect(go.GetComponent<SpriteRenderer>());
            _blinkingEffect.enabled = true;
        }

        /// <summary>
        /// Called every frame.Cheks if expired and andif should blinking.
        /// </summary>
        public void Update() {
            CheckIfExpired();
            CheckIfStartBlinking();
        }

        /// <summary>
        /// Cheks if feed should blink.
        /// </summary>
        private void CheckIfStartBlinking() {
            if (_expireStopwatch.Elapsed.Seconds >= BEGIN_BLINK_SECOND) {
                _blinkingEffect.Update();
            }
        }

        /// <summary>
        /// Check if lifetime expired. If yes then dispatch an event.
        /// </summary>
        private void CheckIfExpired() {
            if (_expireStopwatch.Elapsed.Seconds >= LIFE_TIME_SECONDS) {
                UnityScene.GetController<EventController>().Dispatch<SpecialFeedExpiredEvent>(new EventArgs());
            }
        }

        /// <summary>
        /// Factory method. Instantiantes special feed prefab.
        /// </summary>
        protected override GameObject MakeGameObject() {
            var resourceData = UnityScene.GetResourceManager().resourceData as Snake2DResourceData;
            return MonoBehaviour.Instantiate(resourceData.PREFAB_SPECIAL_FEED);
        }

    }

}
