using UnityEngine;

namespace Game {
    public class BlueFilter : MonoBehaviour {

        public static BlueFilter Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
        }
        
        public void DisableScreen() {
            gameObject.SetActive(false);
        }
        
    }
}