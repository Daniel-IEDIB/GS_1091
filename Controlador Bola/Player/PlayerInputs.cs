using UnityEngine;

namespace Player {
    public class PlayerInputs : MonoBehaviour {
        public Vector2 MoveInput { get; private set; } = Vector2.zero;
        public float ImpulseInput { get; private set; }

        private void Update() {
            HandleInputs();
            ClampInputs();
        }

        private void HandleInputs() {
            HandleMovement();
            HandleImpulse();
        }

        private void HandleMovement() {
            MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void HandleImpulse() {
            ImpulseInput = Input.GetAxis("Impulse");
        }

        private void ClampInputs() {
            MoveInput = Vector2.ClampMagnitude(MoveInput, 1);
            ImpulseInput = Mathf.Clamp(ImpulseInput, -10, 10);
        }
    }
}
