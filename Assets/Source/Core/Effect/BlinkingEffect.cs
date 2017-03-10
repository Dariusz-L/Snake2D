using UnityEngine;

namespace Core.Effect {

    public class BlinkingEffect {

        /// <summary>
        /// Speed of blinking
        /// </summary>
        public float blinkSpeed = 4.0f;

        /// <summary>
        /// Switch enabled.
        /// </summary>
        public bool enabled;

        /// <summary>
        /// Reference to sprite renderer of blinking object.
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        /// <summary>
        /// Current state of blinking.
        /// </summary>
        private BlinkingEffectState state;

        /// <summary>
        /// Constructor. Sets reference to sprite renderer of blinking object.
        /// </summary>
        public BlinkingEffect(SpriteRenderer spriteRenderer) {
            _spriteRenderer = spriteRenderer;
        }

        /// <summary>
        /// Logic of blinking.
        /// </summary>
        public void Update() {
            if (!enabled)
                return;

            Color c =_spriteRenderer.color;
            if (state == BlinkingEffectState.FADE) {
                c.a -= blinkSpeed * Time.deltaTime;

                if (c.a <= 0) {
                    c.a = 0;
                    state = BlinkingEffectState.UNFADE;
                }

            } else if (state == BlinkingEffectState.UNFADE) {
                c.a += blinkSpeed * Time.deltaTime;

                if (c.a >= 1) {
                    c.a = 1;
                    state = BlinkingEffectState.FADE;
                }
            }

            _spriteRenderer.color = c;
        }
    }
}
