using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Submarine {
    public class SubmarineInputs : MonoBehaviour {
        
        public float Emerge;

        private void Update() {
            if (Game.GameStats.GameOver) return;
            HandleInputs();
            ClampInputs();
        }

        private void HandleInputs() {
            Emerge = Input.GetAxis("Emerge");
        }

        private void ClampInputs() {
            Emerge = Mathf.Clamp01(Emerge);
        }
    }
}