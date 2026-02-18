using UnityEngine;

namespace Player {
    public class PlayerInputs : MonoBehaviour {
        public Vector2 MoveInput { get; private set; } = Vector2.zero;
        public bool AttackInput { get; set; }

        private void Update() {
            HandleInputs();
            ClampInputs();
        }

        private void HandleInputs() {
            HandleMovement();
            HandleAttack();
        }

        private void HandleMovement() {
            MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        
        private void HandleAttack() {
            AttackInput = Input.GetKeyDown(KeyCode.Space);
        }

        private void ClampInputs() {
            MoveInput = Vector2.ClampMagnitude(MoveInput, 1);
        }
    }
}
