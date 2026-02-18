using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class RoundsScreen : MonoBehaviour {
        
        public Text RoundsText;

        public void DisplayScreen() {
            GameStats.IsRoundsScreenActive = true;
            gameObject.SetActive(true);
            SetRound();
        }

        public void HideScreen() {
            GameStats.IsRoundsScreenActive = false;
            gameObject.SetActive(false);
        }
        
        private void SetRound() {
            if (!RoundsText) return;
            RoundsText.text = "Round " + GameStats.Round;
        }
    }
}