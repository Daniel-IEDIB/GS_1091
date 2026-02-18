using UnityEngine;

namespace Inputs {
    public class HelicopterInput : MonoBehaviour {
        public float LiftInput { get; private set; }

        public Vector2 TiltInput { get; private set; } = Vector2.zero;

        public float RotateInput { get; private set; }
        public bool RestartInput { get; private set; }


        private void Update() {
            HandleInputs();
            ClampInputs();
        }

        private void HandleInputs(){
            HandleLift();
            HandleTilt();
            HandleRotation();
            HandleRestart();
        }

        private void HandleLift() {
            LiftInput = Input.GetAxis("Throttle");
        }
        
        private void HandleTilt() {
            var input = TiltInput;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            TiltInput = input;
        }

        private void HandleRotation() {
            RotateInput = Input.GetAxis("Rotate");
        }

        private void HandleRestart() {
            RestartInput = Input.GetKeyDown(KeyCode.R);

        }

        private void ClampInputs() {
            LiftInput = Mathf.Clamp(LiftInput, -10f, 10f);
            TiltInput = Vector2.ClampMagnitude(TiltInput, 1);
            RotateInput = Mathf.Clamp(RotateInput, -10f, 10f);
        }
    }
}
